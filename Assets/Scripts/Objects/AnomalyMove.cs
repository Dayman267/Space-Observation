using UnityEngine;

namespace Objects
{
    public sealed class AnomalyMove : AnomalyBase
    {
        private Vector3 originalPosition;
        [SerializeField] private Vector3 movedPosition;
        
        private void Awake() => originalPosition = transform.position;

        public override void CastAnomaly()
        {
            isCasted = true;
            transform.position = movedPosition;
            Debug.Log("Move Anomaly casted");
        }

        public override void FixAnomaly()
        {
            transform.position = originalPosition;
            TriggerAnomalyFixedEvent();
            Debug.Log("Move Anomaly fixed");
        }
    }
}