using System;
using App;
using Systems;
using UnityEngine;
using Zenject;
using UniRx;

namespace Objects
{
    public sealed class AnomaliesInscriptions : IInitializable, IDisposable
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
            anomalyFixedGO.SetActive(false);
            noAnomaliesFoundGO.SetActive(false);
            tooManyAnomaliesGO.SetActive(false);

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

        private void AnomalyFixed() => AnomalyInscriptionUpdate(anomalyFixedGO);

        private void NoAnomaliesFound() => AnomalyInscriptionUpdate(noAnomaliesFoundGO);

        private void TooManyAnomalies() => AnomalyInscriptionUpdate(tooManyAnomaliesGO);

        private void AnomalyInscriptionUpdate(GameObject inscription)
        {
            inscription.SetActive(true);
            showTimeLeft = showingDuration;
            Observable.EveryUpdate().Subscribe(_ =>
            {
                if (showTimeLeft <= 0)
                {
                    inscription.SetActive(false);
                    disposable.Clear();
                }
                showTimeLeft -= Time.deltaTime;
            }).AddTo(disposable);
        }
    }
}