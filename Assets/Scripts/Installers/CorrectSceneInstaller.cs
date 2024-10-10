using App;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers
{
    public sealed class CorrectSceneInstaller : MonoInstaller
    {
        [Header("Buttons")]
        [SerializeField] private Button mainMenuButton;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ReturnToMainMenuButton>()
                .AsSingle()
                .WithArguments(mainMenuButton)
                .NonLazy();
        }
    }
}