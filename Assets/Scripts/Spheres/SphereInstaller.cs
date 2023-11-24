using UnityEngine;
using Zenject;

namespace Spheres
{
    public class SphereInstaller:Installer
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<SphereService>()
                .AsSingle();
            
            Container
                .BindFactory<Vector3, Texture2D, Sphere, Sphere.Factory>()
                .FromFactory<SphereFactory>();
        }
    }
}