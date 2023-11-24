using System.Collections.Generic;
using Spheres.Interfaces;
using UnityEngine;
using Zenject;

namespace Spheres
{
    public class SphereService: ISphereService, IInitializable
    {
        private readonly Sphere.Factory _factory;
        private readonly SphereConfigData _sphereConfig;

        private readonly List<Sphere> _spheres = new();

        public SphereService(Sphere.Factory factory, SphereConfigData sphereConfig)
        {
            _factory = factory;
            _sphereConfig = sphereConfig;
        }

        public void Initialize()
        {
        }

        public void SpawnSpheres()
        {
            var texturesCount = (int)Mathf.Min(_sphereConfig.Count, _sphereConfig.Textures.Length);
            for (int i = 0; i < _sphereConfig.Count; i++)
            {
                var step = i / (float) (_sphereConfig.Count - 1);
                var angle = Mathf.Lerp(0, Mathf.PI*2, step);
                var position = new Vector3(Mathf.Sin(angle)*_sphereConfig.MaxRadius, 0, Mathf.Cos(angle)*_sphereConfig.MaxRadius);

                _spheres.Add(_factory.Create(position, _sphereConfig.Textures[Mathf.Clamp(i, 0, texturesCount)]));
            }
        }

        public void HideSpheres()
        {
            foreach (var sphere in _spheres)
            {
                sphere.Hide();
            }
        }

        public void ShowSpheres()
        {
            foreach (var sphere in _spheres)
            {
                sphere.Show();
            }
        }

        public void ClearSpheres()
        {
            foreach (var sphere in _spheres)
            {
                sphere.Dispose();
            }
            _spheres.Clear();
        }
    }
}