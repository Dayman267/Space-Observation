// using App;
using Systems;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(
        fileName = "GameSystemInstaller",
        menuName = "Installers/New GameSystemInstaller"
    )]
    public sealed class GameSystemInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            // Container.Bind<ApplicationFinisher>().AsSingle();
            
            Container
                .BindInterfacesTo<ExitController>()
                .AsCached();
        }
    }
}