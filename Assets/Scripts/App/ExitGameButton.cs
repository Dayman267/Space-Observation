using System;
using UnityEngine.UI;
using Zenject;

namespace App
{
    public sealed class ExitGameButton : IInitializable, IDisposable
    {
        private readonly Button button;
        private readonly ApplicationFinisher applicationFinisher;

        public ExitGameButton(Button button, ApplicationFinisher applicationFinisher)
        {
            this.button = button;
            this.applicationFinisher = applicationFinisher;
        }

        void IInitializable.Initialize() => button.onClick.AddListener(OnButtonClicked);

        void IDisposable.Dispose() => button.onClick.RemoveListener(OnButtonClicked);

        private void OnButtonClicked() => applicationFinisher.Finish();
    }
}