using App;
using Systems;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers
{
    public sealed class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private Camera camera1;
        [SerializeField] private Camera camera2;
        [SerializeField] private Camera camera3;
        [SerializeField] private Camera camera4;
        [SerializeField] private Camera camera5;
        
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;
        
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromInstance(camera1).AsCached();
            Container.Bind<Camera>().FromInstance(camera2).AsCached();
            Container.Bind<Camera>().FromInstance(camera3).AsCached();
            Container.Bind<Camera>().FromInstance(camera4).AsCached();
            Container.Bind<Camera>().FromInstance(camera5).AsCached();

            Container.BindInterfacesTo<LeftSwitchButton>().AsSingle().WithArguments(leftButton).NonLazy();
            Container.BindInterfacesTo<RightSwitchButton>().AsSingle().WithArguments(rightButton).NonLazy();

            Container.BindInterfacesTo<CameraSwitchController>().AsSingle();
        }
    }
}