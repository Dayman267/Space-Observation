using System;
using UnityEngine.UI;
using Zenject;

namespace App
{
    public class CorrectSceneButton : IInitializable, IDisposable
    {
        private readonly Button button;
        private readonly CorrectSceneLauncher correctSceneLauncher;

        public CorrectSceneButton(Button button, CorrectSceneLauncher correctSceneLauncher)
        {
            this.button = button;
            this.correctSceneLauncher = correctSceneLauncher;
        }
        
        void IInitializable.Initialize()
        {
            button.onClick.AddListener(OnButtonClicked);
        }

        void IDisposable.Dispose()
        {
            button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            correctSceneLauncher.OpenCorrectScene();
        }
    }
}