using App;
using Objects;
using Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers
{
    public sealed class GameSceneInstaller : MonoInstaller
    {
        [Header("Cameras")]
        [SerializeField] private Camera camera1;
        [SerializeField] private Camera camera2;
        [SerializeField] private Camera camera3;
        [SerializeField] private Camera camera4;
        [SerializeField] private Camera camera5;
        
        [Header("Buttons")]
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        [Header("Timer setup")]
        [SerializeField] private TextMeshProUGUI timerTMP;
        [SerializeField] private float secsInMin;
        [SerializeField] private int minsCounter;

        [Header("Anomalies")]
        [SerializeField] private Anomaly cube;
        
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
            
            Container.BindInterfacesTo<AnomaliesController>().AsSingle().NonLazy();
            Container.Bind<IAnomaly>().FromInstance(cube).AsCached();

            Container.Bind<TextMeshProUGUI>().FromInstance(timerTMP).AsSingle();

            Container.BindInterfacesTo<Timer>().AsSingle().WithArguments(secsInMin, minsCounter);
        }
    }
}