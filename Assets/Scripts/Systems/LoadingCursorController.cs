using System;
using App;
using UniRx;
using UnityEngine;
using Zenject;

namespace Systems
{
    public sealed class LoadingCursorController : IInitializable, IDisposable
    {
        private readonly GameObject loadingCursor;
        private readonly RectTransform loadingCursorTransform;
        private readonly float rotationSpeed;
        private bool isLoading;

        private CompositeDisposable disposable;

        public LoadingCursorController(GameObject loadingCursor, float rotationSpeed)
        {
            this.loadingCursor = loadingCursor;
            this.rotationSpeed = rotationSpeed;
            loadingCursorTransform = loadingCursor.GetComponent<RectTransform>();
            disposable = new CompositeDisposable();
        }

        public void Initialize()
        {
            HideLoadingCursor();
            AnomalyChecker.OnCheckStarted += FollowAndRotate;
            AnomalyChecker.OnCheckEnded += HideLoadingCursor;
        }

        public void Dispose()
        {
            AnomalyChecker.OnCheckStarted -= FollowAndRotate;
            AnomalyChecker.OnCheckEnded -= HideLoadingCursor;
        }

        private void FollowAndRotate()
        {
            isLoading = true;
            SingleFollowAndRotation();
            ShowLoadingCursor();
            
            Observable.EveryUpdate().Subscribe(_ =>
            {
                if (!isLoading) disposable.Clear();
                SingleFollowAndRotation();
            }).AddTo(disposable);
        }

        private void SingleFollowAndRotation()
        {
            Vector2 mousePosition = Input.mousePosition;
            loadingCursorTransform.position = mousePosition;
            loadingCursorTransform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        private void ShowLoadingCursor() => loadingCursor.SetActive(true);

        private void HideLoadingCursor()
        {
            isLoading = false;
            loadingCursor.SetActive(false);
        }
    }
}