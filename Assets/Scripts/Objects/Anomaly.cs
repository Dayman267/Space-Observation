using Systems;
using UnityEngine;

namespace Objects
{
    public class Anomaly : MonoBehaviour, IAnomaly
    {
        [SerializeField] private AnomalyType anomalyType;
        //private AnomaliesController anomaliesController;

        public Anomaly(AnomalyType anomalyType)//, AnomaliesController anomaliesController)
        {
            this.anomalyType = anomalyType;
            //this.anomaliesController = anomaliesController;
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
        }
        
        private void HandleDisappear()
        {
            gameObject.SetActive(false);
        }

        private void HandleAppear()
        {
            gameObject.SetActive(true);
        }

        private void HandleMove()
        {
            transform.position += Vector3.right * 2f;
        }

        private void HandleCameraDistortion()
        {
            transform.position += Vector3.right * 2f;
        }

        private void HandleIntruder()
        {
            transform.position += Vector3.right * 2f;
        }

        private void HandleAbyss()
        {
            transform.position += Vector3.right * 2f;
        }

        private void HandleDoorOpenClose()
        {
            transform.position += Vector3.right * 2f;
        }

        private void HandleMeteorite()
        {
            transform.position += Vector3.right * 2f;
        }
    }
}