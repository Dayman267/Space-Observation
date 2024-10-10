using System;
using UnityEngine;

namespace Objects
{
    public class Anomaly : MonoBehaviour, IAnomaly
    {
        [SerializeField] private AnomalyType anomalyType;
        private bool isCasted;

        //private Vector3 normalPosition;
        private Vector3 normalSize;

        public static Action OnAnomalyFixed;

        public Anomaly(AnomalyType anomalyType)
        {
            this.anomalyType = anomalyType;
            //normalPosition = transform.position;
            normalSize = transform.localScale;
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
            switch (anomalyType)
            {
                case AnomalyType.Disappear:
                    HandleAppear();
                    break;
                
                case AnomalyType.Appear:
                    HandleDisappear();
                    break;
                
                case AnomalyType.Move:
                    transform.position -= Vector3.left * 2f;
                    break;
                
                case AnomalyType.CameraDistortion: 
                    HandleDisappear();
                    break;
                
                case AnomalyType.Intruder: 
                    HandleDisappear();
                    break;
                
                case AnomalyType.Abyss: 
                    HandleDisappear();
                    transform.localScale = normalSize;
                    break;
                
                case AnomalyType.DoorOpenClose: break;
                case AnomalyType.Meteorite:
                    HandleDisappear();
                    //transform.position = normalPosition;
                    break;
            }

            isCasted = false;
            OnAnomalyFixed?.Invoke();
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
            Renderer[] components = gameObject.GetComponentsInChildren<Renderer>();
            foreach (var component in components)
                component.enabled = true;
        }

        private void HandleMove()
        {
            isCasted = true;
            transform.position += Vector3.left * 2f;
        }

        private void HandleCameraDistortion()
        {
            isCasted = true;
        }

        private void HandleIntruder()
        {
            HandleAppear();
            isCasted = true;
        }

        private void HandleAbyss()
        {
            isCasted = true;
        }

        private void HandleDoorOpenClose()
        {
            isCasted = true;
        }

        private void HandleMeteorite()
        {
            isCasted = true;
        }
    }
}