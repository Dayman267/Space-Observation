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
        public override void InstallBindings()
        {
            Container
                .Bind<ApplicationFinisher>()
                .AsSingle();
            
            Container
                .Bind<GameLauncher>()
                .AsSingle();
        }
    }
}