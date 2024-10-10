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
        [Header("LoadingCursor")] 
        [SerializeField] private GameObject loadingCursor;
        [SerializeField] private float rotationSpeed;
        
        [Header("Cameras")]
        [SerializeField] private Camera camera1;
        [SerializeField] private Camera camera2;
        [SerializeField] private Camera camera3;
        [SerializeField] private Camera camera4;
        [SerializeField] private Camera camera5;

        [Header("Rooms")]
        [SerializeField] private Anomaly[] room1Anomalies;
        [SerializeField] private Anomaly[] room2Anomalies;
        [SerializeField] private Anomaly[] room3Anomalies;
        [SerializeField] private Anomaly[] room4Anomalies;
        [SerializeField] private Anomaly[] room5Anomalies;
        
        [Header("Buttons")]
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        [Header("Timer setup")]
        [SerializeField] private TextMeshProUGUI timerTMP;
        [SerializeField] private float secsInMin;
        [SerializeField] private int minsCounter;
        [SerializeField] private int finalHour;

        [Header("Anomalies")] 
        [SerializeField] private float anomalyCastChancePerSec;
        [SerializeField] private int anomalyLimit;
        [SerializeField] private float anomalyCheckDuration;

        [Header("Texts")] 
        [SerializeField] private GameObject anomalyFixedGO;
        [SerializeField] private GameObject noAnomaliesFoundGO;
        [SerializeField] private GameObject tooManyAnomaliesGO;
        [SerializeField] private float textShowingDuration;
        [SerializeField] private GameObject winScreen;
        
        public override void InstallBindings()
        {
            InstallCameras();

            Container.BindInterfacesTo<LoadingCursorController>().AsSingle()
                .WithArguments(loadingCursor, rotationSpeed);

            Container.BindInterfacesTo<LeftSwitchButton>().AsSingle().WithArguments(leftButton).NonLazy();
            Container.BindInterfacesTo<RightSwitchButton>().AsSingle().WithArguments(rightButton).NonLazy();

            Container.BindInterfacesTo<CameraSwitchController>().AsSingle();

            InstallRooms();
            
            Container.BindInterfacesAndSelfTo<AnomalyChecker>().AsSingle().WithArguments(anomalyCheckDuration);
            Container.BindInterfacesTo<AnomaliesController>().AsSingle()
                .WithArguments(anomalyCastChancePerSec, anomalyLimit).NonLazy();

            Container.BindInterfacesTo<TimerController>().AsSingle().WithArguments(secsInMin, minsCounter, finalHour);
            Container.Bind<TimerView>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesTo<AnomaliesInscriptions>().AsSingle()
                .WithArguments(anomalyFixedGO, noAnomaliesFoundGO, tooManyAnomaliesGO, textShowingDuration);

            Container.BindInterfacesTo<WinHandler>().AsSingle().WithArguments(winScreen, textShowingDuration);

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
            Container.Bind<Room>().AsCached().WithArguments(camera3, room3Anomalies);
            Container.Bind<Room>().AsCached().WithArguments(camera4, room4Anomalies);
            Container.Bind<Room>().AsCached().WithArguments(camera5, room5Anomalies);
        }
    }
}