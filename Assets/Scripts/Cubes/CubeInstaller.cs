using Input.Interface;
using UnityEngine;
using Zenject;

namespace Cubes
{
    public class CubeInstaller: Installer
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<CubeService>()
                .AsSingle();

            Container
                .BindFactory<Vector3, IMoveInput, Color, Cube, Cube.Factory>()
                .FromComponentInNewPrefabResource("Prefabs/Cube");
        }
    }
}