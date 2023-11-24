using Cubes;
using Game;
using Input;
using Spheres;
using Zenject;

namespace Base
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Install<InputInstaller>();
            Container.Install<SphereInstaller>();
            Container.Install<CubeInstaller>();
            Container.Install<GameInstaller>();
        }
    }
}