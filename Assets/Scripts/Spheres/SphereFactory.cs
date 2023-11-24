using UnityEngine;
using Zenject;

namespace Spheres
{
    public class SphereFactory: IFactory<Vector3, Texture2D, Sphere>
    {
        private static readonly int BaseMap = Shader.PropertyToID("_BaseMap");
        
        private readonly DiContainer _diContainer;
        private readonly SphereConfigData _config;
        
        public SphereFactory(DiContainer diContainer, SphereConfigData config)
        {
            _diContainer = diContainer;
            _config = config;
        }

        public Sphere Create(Vector3 position, Texture2D texture2D)
        {
            var sphere = _diContainer.InstantiatePrefabForComponent<Sphere>(_config.SpherePrefab);
            sphere.transform.position = position;
            
            var material = new Material(_config.SphereMaterial);
            material.SetTexture(BaseMap, texture2D);
            sphere.SetMaterial(material);
            
            return sphere;
        }
    }
}