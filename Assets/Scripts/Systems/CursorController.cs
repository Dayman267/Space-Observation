using System;
using Systems;
using UnityEngine;
using Zenject;

namespace App
{
    public sealed class CursorController : IInitializable, IDisposable
    {
        private readonly Texture2D customCursor;
        private readonly Vector2 hotSpot;
        private readonly CursorMode cursorMode;

        public CursorController(Texture2D customCursor, CursorHotspotPosition hotspotPosition)
        {
            this.customCursor = customCursor;
            cursorMode = CursorMode.Auto;

            hotSpot = hotspotPosition switch
            {
                CursorHotspotPosition.TopLeft => Vector2.zero,
                CursorHotspotPosition.Center => new Vector2(customCursor.width / 2f, customCursor.height / 2f),
                _ => hotSpot
            };
        }
        
        public void Initialize()
        {
            ChangeCursorToCommon();
            AnomalyChecker.OnCheckStarted += HideCursor;
            AnomalyChecker.OnCheckEnded += ShowCursor;
        }

        public void Dispose()
        {
            AnomalyChecker.OnCheckStarted -= HideCursor;
            AnomalyChecker.OnCheckEnded -= ShowCursor;
        }

        private void ChangeCursorToCommon() => Cursor.SetCursor(customCursor, hotSpot, cursorMode);
        
        private void HideCursor() => Cursor.visible = false;
        private void ShowCursor() => Cursor.visible = true;
    }
}