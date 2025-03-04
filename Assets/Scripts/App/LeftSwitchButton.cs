using System;
using Systems;
using UnityEngine.UI;
using Zenject;

namespace App
{
    public sealed class LeftSwitchButton : IInitializable, IDisposable
    {
        private readonly Button button;
        private readonly ICameraSwitchController cameraSwitchController;

        public LeftSwitchButton(Button button, ICameraSwitchController cameraSwitchController)
        {
            this.button = button;
            this.cameraSwitchController = cameraSwitchController;
        }

        void IInitializable.Initialize() => button.onClick.AddListener(OnButtonClicked);

        void IDisposable.Dispose() => button.onClick.RemoveListener(OnButtonClicked);

        private void OnButtonClicked() => cameraSwitchController.SwitchLeft();
    }
}