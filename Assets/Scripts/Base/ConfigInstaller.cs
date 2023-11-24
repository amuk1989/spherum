using UnityEngine;
using Zenject;

namespace Base
{
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ConfigInstaller")]
    public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
    {
        [SerializeField] private GameConfig _gameConfig;
    
        public override void InstallBindings()
        {
            Container
                .Bind<SphereConfigData>()
                .FromInstance(_gameConfig.ConfigData)
                .AsSingle();
        }
    }
}