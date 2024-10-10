using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace App
{
    public sealed class WinHandler : IInitializable, IDisposable
    {
        private readonly GameObject winScreen;
        private readonly MainMenuLauncher mainMenuLauncher;
        private readonly float showingDuration;

        private CompositeDisposable disposable;

        public WinHandler(GameObject winScreen, MainMenuLauncher mainMenuLauncher, float showingDuration)
        {
            this.winScreen = winScreen;
            this.mainMenuLauncher = mainMenuLauncher;
            this.showingDuration = showingDuration;
            
            disposable = new CompositeDisposable();
        }

        public void Initialize()
        {
            Timer.OnShiftEnded += WaitAndGoToTheMainMenu;
        }

        public void Dispose()
        {
            Timer.OnShiftEnded -= WaitAndGoToTheMainMenu;
        }

        private void WaitAndGoToTheMainMenu()
        {
            float showTimeLeft = showingDuration;
            winScreen.SetActive(true);
            Observable.EveryUpdate().Subscribe(_ =>
            {
                if (showTimeLeft <= 0)
                {
                    mainMenuLauncher.GoToMainMenu();
                    disposable.Clear();
                }
                showTimeLeft -= Time.deltaTime;
            }).AddTo(disposable);
        }
    }
}