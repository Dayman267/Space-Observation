using UnityEngine;

namespace Objects
{
    public class Anomaly : MonoBehaviour, IAnomaly
    {
        [SerializeField] private AnomalyType anomalyType;
        private bool isCasted;

        public Anomaly(AnomalyType anomalyType)
        {
            this.anomalyType = anomalyType;
        }

        public void CastAnomaly()
        {
            switch (anomalyType)
            {
                case AnomalyType.Disappear:        HandleDisappear(); break;
                case AnomalyType.Appear:           HandleAppear(); break;
                case AnomalyType.Move:             HandleMove(); break;
                case AnomalyType.CameraDistortion: HandleCameraDistortion(); break;
                case AnomalyType.Intruder:         HandleIntruder(); break;
                case AnomalyType.Abyss:            HandleAbyss(); break;
                case AnomalyType.DoorOpenClose:    HandleDoorOpenClose(); break;
                case AnomalyType.Meteorite:        HandleMeteorite(); break;
            }
            
            Debug.Log("casted");
        }

        public bool IsCasted() => isCasted;

        public void FixAnomaly()
        {
            isCasted = false;
            Renderer[] components = gameObject.GetComponentsInChildren<Renderer>();
            foreach (var component in components)
                component.enabled = true;
            Debug.Log("Fixed");
        }

        private void HandleDisappear()
        {
            isCasted = true;
            Renderer[] components = gameObject.GetComponentsInChildren<Renderer>();
            foreach (var component in components)
                component.enabled = false;
        }

        private void HandleAppear()
        {
            isCasted = true;
            gameObject.SetActive(true);
        }

        private void HandleMove()
        {
            isCasted = true;
            transform.position += Vector3.right * 2f;
        }

        private void HandleCameraDistortion()
        {
            isCasted = true;
            transform.position += Vector3.right * 2f;
        }

        private void HandleIntruder()
        {
            isCasted = true;
            transform.position += Vector3.right * 2f;
        }

        private void HandleAbyss()
        {
            isCasted = true;
            transform.position += Vector3.right * 2f;
        }

        private void HandleDoorOpenClose()
        {
            isCasted = true;
            transform.position += Vector3.right * 2f;
        }

        private void HandleMeteorite()
        {
            isCasted = true;
            transform.position += Vector3.right * 2f;
        }
    }
}