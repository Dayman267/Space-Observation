using System;
using App;
using Systems;
using UnityEngine;
using Zenject;
using UniRx;

namespace Objects
{
    public class AnomaliesInscriptions : IInitializable, IDisposable
    {
        private readonly GameObject anomalyFixedGO;
        private readonly GameObject noAnomaliesFoundGO;
        private readonly GameObject tooManyAnomaliesGO;

        private readonly float showingDuration;
        private float showTimeLeft;

        private CompositeDisposable disposable;

        public AnomaliesInscriptions(GameObject anomalyFixedGO, GameObject noAnomaliesFoundGO,
            GameObject tooManyAnomaliesGO, float showingDuration)
        {
            this.anomalyFixedGO = anomalyFixedGO;
            this.noAnomaliesFoundGO = noAnomaliesFoundGO;
            this.tooManyAnomaliesGO = tooManyAnomaliesGO;

            this.showingDuration = showingDuration;
            
            disposable = new CompositeDisposable();
        }


        public void Initialize()
        {
            HideAnomalyFixedGO();
            HideNoAnomaliesFoundGO();
            HideTooManyAnomaliesGO();

            Anomaly.OnAnomalyFixed += AnomalyFixed;
            AnomalyChecker.OnAnomalyNotSpotted += NoAnomaliesFound;
            AnomaliesController.OnLimitExceeded += TooManyAnomalies;
        }

        public void Dispose()
        {
            Anomaly.OnAnomalyFixed -= AnomalyFixed;
            AnomalyChecker.OnAnomalyNotSpotted -= NoAnomaliesFound;
            AnomaliesController.OnLimitExceeded -= TooManyAnomalies;
        }

        private void AnomalyFixed()
        {
            ShowAnomalyFixedGO();
            showTimeLeft = showingDuration;
            Observable.EveryUpdate().Subscribe(_ =>
            {
                if (showTimeLeft <= 0)
                {
                    HideAnomalyFixedGO();
                    disposable.Clear();
                }
                showTimeLeft -= Time.deltaTime;
            }).AddTo(disposable);
        }

        private void NoAnomaliesFound()
        {
            ShowNoAnomaliesFoundGO();
            showTimeLeft = showingDuration;
            Observable.EveryUpdate().Subscribe(_ =>
            {
                if (showTimeLeft <= 0)
                {
                    HideNoAnomaliesFoundGO();
                    disposable.Clear();
                }
                showTimeLeft -= Time.deltaTime;
            }).AddTo(disposable);
        }

        private void TooManyAnomalies()
        {
            ShowTooManyAnomaliesGO();
            showTimeLeft = showingDuration;
            Observable.EveryUpdate().Subscribe(_ =>
            {
                if (showTimeLeft <= 0)
                {
                    HideTooManyAnomaliesGO();
                    disposable.Clear();
                }
                showTimeLeft -= Time.deltaTime;
            }).AddTo(disposable);
        }

        private void ShowAnomalyFixedGO() => anomalyFixedGO.SetActive(true);
        private void ShowNoAnomaliesFoundGO() => noAnomaliesFoundGO.SetActive(true);
        private void ShowTooManyAnomaliesGO() => tooManyAnomaliesGO.SetActive(true);
        
        private void HideAnomalyFixedGO() => anomalyFixedGO.SetActive(false);
        private void HideNoAnomaliesFoundGO() => noAnomaliesFoundGO.SetActive(false);
        private void HideTooManyAnomaliesGO() => tooManyAnomaliesGO.SetActive(false);
    }
}