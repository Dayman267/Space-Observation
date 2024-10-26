using System;
using UnityEngine;

namespace Objects
{
    public abstract class AnomalyBase : MonoBehaviour, IAnomaly
    {
        protected bool isCasted;
        public static Action OnAnomalyFixed;

        public abstract void CastAnomaly();
        public abstract void FixAnomaly();

        public bool IsCasted() => isCasted;

        protected void TriggerAnomalyFixedEvent()
        {
            isCasted = false;
            OnAnomalyFixed?.Invoke();
        }
    }
}