using System;
using TMPro;
using UniRx;
using UnityEngine;
using IInitializable = Zenject.IInitializable;

namespace App
{
    public class Timer : IInitializable
    {
        private TextMeshProUGUI textMP;
        private readonly float secsInMin;
        private readonly int minsCounter;
        private readonly int finalHour;
        private int minsPassed;
        private float secsRemained;
        private uint hours = 12;
        private uint minutes;

        public static Action OnShiftEnded;

        private CompositeDisposable disposable;

        public Timer(TextMeshProUGUI textMP, float secsInMin, int minsCounter, int finalHour)
        {
            this.textMP = textMP;
            this.secsInMin = secsInMin;
            this.minsCounter = minsCounter;
            this.finalHour = finalHour;

            disposable = new CompositeDisposable();
        }

        public void Initialize()
        {
            textMP.text = "12:00 AM";
            StartTimer();
        }

        private void StartTimer()
        {
            Observable.EveryUpdate().Subscribe(_ =>
            {
                if (secsRemained <= 0)
                {
                    if (minsPassed == minsCounter)
                    {
                        textMP.text = minutes < 10 ? $"{hours}:0{minutes} AM" : $"{hours}:{minutes} AM";
                        minsPassed = 0;
                    }
                
                    minutes++;
                    if (minutes == 60)
                    {
                        hours = hours == 12 ? 1 : ++hours;
                        if (hours == finalHour)
                        {
                            OnShiftEnded?.Invoke();
                            disposable.Clear();
                        }
                        minutes = 0;
                    }
                    secsRemained = secsInMin;
                    minsPassed++;
                }
                else secsRemained -= Time.deltaTime;
            }).AddTo(disposable);
        }
    }
}