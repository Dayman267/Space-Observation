using System;
using Objects;
using UnityEngine;
using Zenject;

namespace App
{
    public sealed class AnomalyChecker : ITickable
    {
        private readonly float maxDistance = Mathf.Infinity;
        private readonly LayerMask layers = LayerMask.NameToLayer("UI");
        private Camera[] cameras;

        public static Action<IAnomaly> OnAnomalySpotted;

        [Inject]
        public void Construct(Camera[] cameras)
        {
            this.cameras = cameras;
        }

        public void Tick()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            foreach (var camera in cameras)
            {
                if (!camera.isActiveAndEnabled) continue;

                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layers))
                {
                    IAnomaly anomaly = hit.collider.GetComponentInParent<IAnomaly>();

                    if (anomaly != null && anomaly.IsCasted())
                    {
                        OnAnomalySpotted?.Invoke(anomaly);
                    }
                }
            }
        }
    }
}