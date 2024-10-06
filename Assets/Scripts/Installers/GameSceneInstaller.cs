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

        [Header("Rooms")]
        [SerializeField] private Anomaly[] room1Anomalies;
        [SerializeField] private Anomaly[] room2Anomalies;
        
        [Header("Buttons")]
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        [Header("Timer setup")]
        [SerializeField] private TextMeshProUGUI timerTMP;
        [SerializeField] private float secsInMin;
        [SerializeField] private int minsCounter;

        [Header("Anomalies")] 
        [SerializeField] private float anomalyCastChancePerSec;
        
        public override void InstallBindings()
        {
            InstallCameras();

            Container.BindInterfacesTo<LeftSwitchButton>().AsSingle().WithArguments(leftButton).NonLazy();
            Container.BindInterfacesTo<RightSwitchButton>().AsSingle().WithArguments(rightButton).NonLazy();

            Container.BindInterfacesTo<CameraSwitchController>().AsSingle();

            InstallRooms();
            
            Container.BindInterfacesTo<AnomaliesController>().AsSingle().WithArguments(anomalyCastChancePerSec).NonLazy();

            Container.Bind<TextMeshProUGUI>().FromInstance(timerTMP).AsSingle();
            Container.BindInterfacesTo<Timer>().AsSingle().WithArguments(secsInMin, minsCounter);

            Container.BindInterfacesTo<InputManager>().AsSingle();
        }

        private void InstallCameras()
        {
            Container.Bind<Camera>().FromInstance(camera1).AsCached();
            Container.Bind<Camera>().FromInstance(camera2).AsCached();
            Container.Bind<Camera>().FromInstance(camera3).AsCached();
            Container.Bind<Camera>().FromInstance(camera4).AsCached();
            Container.Bind<Camera>().FromInstance(camera5).AsCached();
        }

        private void InstallRooms()
        {
            Container.Bind<Room>().AsCached().WithArguments(camera1, room1Anomalies);
            Container.Bind<Room>().AsCached().WithArguments(camera2, room2Anomalies);
        }
    }
}