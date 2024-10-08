using System;
using Systems;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;
using Object = UnityEngine.Object;

namespace App
{
    public sealed class CursorController : IInitializable, IDisposable
    {
        private readonly Texture2D customCursor;
        private readonly Texture2D loadingCursor;
        private readonly Vector2 hotSpot;
        private readonly CursorMode cursorMode;

        //private readonly GameObject loadingCursorUI;
        //private readonly RectTransform loadingCursorTransform;
        //private readonly float rotationSpeed;

        //private bool isLoading;

        // public CursorController(Texture2D customCursor, GameObject loadingCursorPrefab,
        //     CursorHotspotPosition hotspotPosition, Transform parent, float rotationSpeed)
        // {
        //     this.customCursor = customCursor;
        //     this.loadingCursorUI = loadingCursorPrefab;
        //     this.rotationSpeed = rotationSpeed;
        //     cursorMode = CursorMode.Auto;
        //
        //     switch (hotspotPosition)
        //     {
        //         case CursorHotspotPosition.TopLeft:
        //             hotSpot = Vector2.zero;
        //             break;
        //
        //         case CursorHotspotPosition.Center:
        //             hotSpot = new Vector2(customCursor.width / 2, customCursor.height / 2);
        //             break;
        //     }
        //
        //     loadingCursorTransform = loadingCursorUI.GetComponent<RectTransform>();
        //     GameObject loadingCursorObj = Object.Instantiate(loadingCursorUI);
        //     SceneManager.MoveGameObjectToScene(loadingCursorObj, ));
        //     
        //     loadingCursorUI.SetActive(false);
        // }
        
        // public void Initialize()
        // {
        //     ChangeCursorToCommon();
        //     AnomalyChecker.OnCheckStarted += StartLoadingCursor;
        //     AnomalyChecker.OnCheckEnded += StopLoadingCursor;
        // }
        //
        // public void Dispose()
        // {
        //     AnomalyChecker.OnCheckStarted -= StartLoadingCursor;
        //     AnomalyChecker.OnCheckEnded -= StopLoadingCursor;
        // }
        
        // public void Tick()
        // {
        //     if (!isLoading) return;
        //
        //     Vector2 mousePosition = Input.mousePosition;
        //     loadingCursorTransform.position = mousePosition;
        //     loadingCursorTransform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        // }
        //
        // private void StartLoadingCursor()
        // {
        //     isLoading = true;
        //     Cursor.visible = false;
        //     loadingCursorUI.SetActive(true);
        // }
        //
        // private void StopLoadingCursor()
        // {
        //     isLoading = false;
        //     Cursor.visible = true;
        //     loadingCursorUI.SetActive(false);
        // }

        public CursorController(Texture2D customCursor, Texture2D loadingCursor,
            CursorHotspotPosition hotspotPosition)
        {
            this.customCursor = customCursor;
            this.loadingCursor = loadingCursor;
            cursorMode = CursorMode.Auto;

            switch (hotspotPosition)
            {
                case CursorHotspotPosition.TopLeft:
                    hotSpot = Vector2.zero;
                    break;

                case CursorHotspotPosition.Center:
                    hotSpot = new Vector2(customCursor.width / 2, customCursor.height / 2);
                    break;
            }
        }
        
        public void Initialize()
        {
            ChangeCursorToCommon();
            AnomalyChecker.OnCheckStarted += ChangeCursorToLoading;
            AnomalyChecker.OnCheckEnded += ChangeCursorToCommon;
        }

        public void Dispose()
        {
            AnomalyChecker.OnCheckStarted -= ChangeCursorToLoading;
            AnomalyChecker.OnCheckEnded -= ChangeCursorToCommon;
        }

        private void ChangeCursorToCommon() => Cursor.SetCursor(customCursor, hotSpot, cursorMode);
        
        private void ChangeCursorToLoading() => Cursor.SetCursor(loadingCursor, hotSpot, cursorMode);
    }
}