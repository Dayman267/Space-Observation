using App;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers
{
    public sealed class MenuSceneInstaller : MonoInstaller
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<StartGameButton>()
                .AsSingle()
                .WithArguments(startButton)
                .NonLazy();
            
            Container
                .BindInterfacesTo<ExitGameButton>()
                .AsSingle()
                .WithArguments(exitButton)
                .NonLazy();
        }
    }
}