using Zenject;

namespace Game
{
    public class GameInstaller: Installer
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<GameRule>()
                .AsSingle();
        }
    }
}