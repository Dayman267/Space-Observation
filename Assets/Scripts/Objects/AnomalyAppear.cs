using UnityEngine;

namespace Objects
{
    public sealed class AnomalyAppear : AnomalyBase
    {
        public override void CastAnomaly()
        {
            isCasted = true;
            ToggleRenderers(true);
            Debug.Log("Appear Anomaly casted");
        }

        public override void FixAnomaly()
        {
            ToggleRenderers(false);
            TriggerAnomalyFixedEvent();
            Debug.Log("Appear Anomaly fixed");
        }
        
        private void ToggleRenderers(bool isEnabled)
        {
            foreach (var renderer in GetComponentsInChildren<Renderer>())
                renderer.enabled = isEnabled;
        }
    }
}