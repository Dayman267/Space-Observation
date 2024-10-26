using System;
using Zenject;
using UnityEngine.UI;

namespace App
{
    public sealed class StartGameButton : IInitializable, IDisposable
    {
        private readonly Button button;
        private readonly GameLauncher gameLauncher;

        public StartGameButton(Button button, GameLauncher gameLauncher)
        {
            this.button = button;
            this.gameLauncher = gameLauncher;
        }

        void IInitializable.Initialize() => button.onClick.AddListener(OnButtonClicked);

        void IDisposable.Dispose() => button.onClick.RemoveListener(OnButtonClicked);

        private void OnButtonClicked() => gameLauncher.StartGame();
    }
}