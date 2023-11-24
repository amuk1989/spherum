using System;
using Cubes.Interfaces;
using Input.Interface;
using Spheres.Interfaces;
using UniRx;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game
{
    public class GameRule: IInitializable, IDisposable
    {
        private readonly ICubeService _cubeService;
        private readonly ISphereService _sphereService;
        private readonly IInputService _inputService;

        private readonly CompositeDisposable _disposable = new();

        public GameRule(ICubeService cubeService, ISphereService sphereService, IInputService inputService)
        {
            _cubeService = cubeService;
            _sphereService = sphereService;
            _inputService = inputService;
        }

        public void Initialize()
        {
            _inputService.InitiateInputs();
            _sphereService.SpawnSpheres();
            _cubeService.SpawnCubes();

            _cubeService
                .CubesDistanceAsObservable()
                .Where(value => value < 1f)
                .Subscribe(value => NextStage())
                .AddTo(_disposable);
        }

        private void NextStage()
        {
            _sphereService.ClearSpheres();
            _cubeService.DestroyCubes();
            SceneManager.LoadScene("NextScene");
        }

        public void Dispose()
        {
            
        }
    }
}