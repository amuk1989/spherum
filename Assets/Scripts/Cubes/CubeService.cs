using System;
using Cubes.Interfaces;
using Input.Interface;
using Spheres.Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

namespace Cubes
{
    public class CubeService: ICubeService, IInitializable, IDisposable
    {
        private const float SphereShowDistance = 2f;
        
        private readonly Cube.Factory _cubeFactory;
        private readonly IInputService _inputService;
        private readonly ISphereService _sphereService;
        
        private readonly Vector3 _greenSpawnPosition = new Vector3(1.5f, 0, 0);
        private readonly Vector3 _redSpawnPosition = new Vector3(-1.5f, 0, 0);
        private readonly ReactiveProperty<float> _distance = new(3f);

        private Cube _greenCube;
        private Cube _redCube;

        private IDisposable _distanceFlow;

        public CubeService(Cube.Factory cubeFactory, IInputService inputService, ISphereService sphereService)
        {
            _cubeFactory = cubeFactory;
            _inputService = inputService;
            _sphereService = sphereService;
        }

        public void Initialize()
        {
        }

        public IObservable<float> CubesDistanceAsObservable() => _distance.AsObservable();

        public void SpawnCubes()
        {
            _greenCube = _cubeFactory.Create(_greenSpawnPosition, _inputService.GetAlternativeInputModel(), Color.green);
            _redCube = _cubeFactory.Create(_redSpawnPosition, _inputService.GetInputModel(), Color.red);
            
            _greenCube.SetTarget(_redCube);
            _redCube.SetTarget(_greenCube);

            _distanceFlow = Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    _distance.Value = (_greenCube.transform.position - _redCube.transform.position).magnitude;
                        
                    if (_distance.Value < SphereShowDistance)
                    {
                        _sphereService.ShowSpheres();
                    }
                    else
                    {
                        _sphereService.HideSpheres();
                    }
                });
        }

        public void DestroyCubes()
        {
            _distanceFlow?.Dispose();
            _greenCube.Dispose();
            _redCube.Dispose();
        }

        public void Dispose()
        {
            _distanceFlow?.Dispose();
        }
    }
}