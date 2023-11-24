using Zenject;

namespace Input
{
    public class InputInstaller: Installer
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<InputService>()
                .AsSingle();
            
            Container
                .BindFactory<KeyCodeData, InputModel, InputModel.Factory>();
        }
    }
}