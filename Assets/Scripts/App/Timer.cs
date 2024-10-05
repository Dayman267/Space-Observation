using TMPro;
using UnityEngine;
using Zenject;

namespace App
{
    public class Timer : IInitializable, ITickable
    {
        private TextMeshProUGUI textMP;
        private readonly float secsInMin;
        private readonly int minsCounter;
        private int minsPassed;
        private float secsRemained;
        private uint hours = 12;
        private uint minutes;

        public Timer(TextMeshProUGUI textMP, float secsInMin, int minsCounter)
        {
            this.textMP = textMP;
            this.secsInMin = secsInMin;
            this.minsCounter = minsCounter;
        }

        public void Initialize()
        {
            textMP.text = "12:00 AM";
        }

        public void Tick()
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
                    minutes = 0;
                }
                secsRemained = secsInMin;
                minsPassed++;
            }
            else secsRemained -= Time.deltaTime;
        }
    }
}