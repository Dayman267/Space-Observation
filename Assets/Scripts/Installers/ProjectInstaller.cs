using Systems;
using UnityEngine;
using Zenject;

namespace App
{
    [CreateAssetMenu(
        fileName = "ProjectInstaller",
        menuName = "Installers/New ProjectInstaller"
    )]
    public sealed class ProjectInstaller : ScriptableObjectInstaller
    {
        [Header("Cursor")]
        [SerializeField] private Texture2D cursor;
        [SerializeField] private CursorHotspotPosition cursorHotspotPosition;
        
        public override void InstallBindings()
        {
            Container
                .Bind<ApplicationFinisher>()
                .AsSingle();
            
            Container
                .Bind<GameLauncher>()
                .AsSingle();

            Container
                .BindInterfacesTo<CursorController>()
                .AsSingle()
                .WithArguments(cursor, cursorHotspotPosition);

            Container
                .Bind<MainMenuLauncher>()
                .AsSingle();
        }
    }
}