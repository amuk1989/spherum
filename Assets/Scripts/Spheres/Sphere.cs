using System;
using UnityEngine;
using Zenject;

namespace Spheres
{
    public class Sphere : MonoBehaviour, IDisposable
    {
        public class Factory: PlaceholderFactory<Vector3, Texture2D, Sphere>
        {
        }
    
        [SerializeField] private Renderer _renderer;

        public void SetMaterial(Material material)
        {
            _renderer.sharedMaterial = material;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
