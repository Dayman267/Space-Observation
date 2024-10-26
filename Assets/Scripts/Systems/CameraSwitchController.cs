using UnityEngine;
using Zenject;

namespace Systems
{
    public sealed class CameraSwitchController : ICameraSwitchController
    {
        private Camera[] cameras;
        private int selectedCameraIndex;
        private int currentCameraIndex;

        [Inject]
        public void Construct(Camera[] cameras) => this.cameras = cameras;

        public void SwitchLeft() => SelectCamera(1);
        public void SwitchRight() => SelectCamera(-1);

        private void SelectCamera(int indexDirection)
        {
            selectedCameraIndex = isSelectionInBounds(indexDirection)
                    ? selectedCameraIndex + indexDirection
                    : IsSelectionAtEnd(indexDirection) ? 0 : cameras.Length - 1;

            cameras[selectedCameraIndex].gameObject.SetActive(true);
            cameras[currentCameraIndex].gameObject.SetActive(false);
            currentCameraIndex = selectedCameraIndex;
        }

        private bool isSelectionInBounds(int indexDirection)
            => selectedCameraIndex + indexDirection >= 0 
               && selectedCameraIndex + indexDirection <= cameras.Length - 1;

        private bool IsSelectionAtEnd(int indexDirection) 
            => selectedCameraIndex + indexDirection == cameras.Length;
    }
}