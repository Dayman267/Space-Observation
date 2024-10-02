using UnityEngine;
using Zenject;

namespace Systems
{
    public sealed class CameraSwitchController : ICameraSwitchController
    {
        private Camera[] cameras;
        private int selectedCamera;
        private int currentCamera;

        [Inject]
        public void Construct(Camera[] cameras)
        {
            this.cameras = cameras;
        }

        public void SwitchLeft() => SelectCamera(1);
        public void SwitchRight() => SelectCamera(-1);

        private void SelectCamera(int index)
        {
            selectedCamera = selectedCamera + index >= 0 &&
                             selectedCamera + index <= cameras.Length - 1
                ? selectedCamera + index
                : selectedCamera + index == cameras.Length
                    ? 0
                    : cameras.Length - 1;

            cameras[selectedCamera].gameObject.SetActive(true);
            cameras[currentCamera].gameObject.SetActive(false);
            currentCamera = selectedCamera;
        }
    }
}