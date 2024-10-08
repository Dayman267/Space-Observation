using System;
using Objects;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace App
{
    public sealed class AnomalyChecker : ITickable
    {
        private readonly Camera[] cameras;
        private readonly float anomalyCheckDuration;
        private float checkTimeLeft;
        private bool isChecking;
        private IAnomaly anomaly;

        public static Action OnCheckStarted;
        public static Action OnCheckEnded;
        public static Action<IAnomaly> OnAnomalySpotted;
        
        public AnomalyChecker(Camera[] cameras, float anomalyCheckDuration)
        {
            this.cameras = cameras;
            this.anomalyCheckDuration = anomalyCheckDuration;
        }

        public void Tick()
        {
            if (isChecking)
            {
                if (checkTimeLeft <= 0)
                {
                    EndCheck();
                }
                checkTimeLeft -= Time.deltaTime;
                return;
            }
            
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                CheckForAnomaly();
        }
        
        private void CheckForAnomaly()
        {
            foreach (var camera in cameras)
            {
                if (!camera.isActiveAndEnabled) continue;

                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    anomaly = hit.collider.GetComponentInParent<IAnomaly>();

                    StartCheck();
                }
            }
        }
        
        private void StartCheck()
        {
            isChecking = true;
            checkTimeLeft = anomalyCheckDuration;
            OnCheckStarted?.Invoke();
        }

        private void EndCheck()
        {
            isChecking = false;
            OnCheckEnded?.Invoke();

            if (anomaly != null && anomaly.IsCasted())
            {
                OnAnomalySpotted?.Invoke(anomaly);
            }
        }
    }
}