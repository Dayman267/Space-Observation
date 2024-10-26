using System;
using UnityEngine.UI;
using Zenject;

namespace App
{
    public sealed class ReturnToMainMenuButton : IInitializable, IDisposable
    {
        private readonly Button button;
        private readonly MainMenuLauncher mainMenuLauncher;

        public ReturnToMainMenuButton(Button button, MainMenuLauncher mainMenuLauncher)
        {
            this.button = button;
            this.mainMenuLauncher = mainMenuLauncher;
        }
        
        void IInitializable.Initialize() => button.onClick.AddListener(OnButtonClicked);

        void IDisposable.Dispose() => button.onClick.RemoveListener(OnButtonClicked);

        private void OnButtonClicked() => mainMenuLauncher.GoToMainMenu();
    }
}