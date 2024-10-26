using UnityEngine;

namespace Objects
{
    public sealed class AnomalyDisappear : AnomalyBase
    {
        public override void CastAnomaly()
        {
            isCasted = true;
            ToggleRenderers(false);
            Debug.Log("Disappear Anomaly casted");
        }

        public override void FixAnomaly()
        {
            ToggleRenderers(true);
            TriggerAnomalyFixedEvent();
            Debug.Log("Disappear Anomaly fixed");
        }
        
        private void ToggleRenderers(bool isEnabled)
        {
            foreach (var renderer in GetComponentsInChildren<Renderer>())
                renderer.enabled = isEnabled;
        }
    }
}