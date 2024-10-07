using System;
using System.Linq;
using App;
using Objects;
using UnityEngine;
using Zenject;
using IInitializable = Zenject.IInitializable;
using Random = UnityEngine.Random;

namespace Systems
{
    public sealed class AnomaliesController : IInitializable, ITickable, IDisposable

    {
        private readonly Room[] rooms;
        private float anomalyCastChancePerSec;
        private float secsLeft = 1;

        public AnomaliesController(Room[] rooms, float anomalyCastChancePerSec)
        {
            this.rooms = rooms;
            this.anomalyCastChancePerSec = anomalyCastChancePerSec;
        }

        public void Initialize()
        {
            anomalyCastChancePerSec /= 100;
            AnomalyChecker.OnAnomalySpotted += FixSpottedAnomaly;
        }

        public void Dispose()
        {
            AnomalyChecker.OnAnomalySpotted -= FixSpottedAnomaly;
        }

        public void Tick()
        {
            if (secsLeft <= 0)
            {
                if (Random.value <= anomalyCastChancePerSec) TriggerAnomaly();
                secsLeft = 1;
            }
            else secsLeft -= Time.deltaTime;
        }

        private void TriggerAnomaly()
        {
            int allAnomaliesCount = rooms.Sum(room => room.Anomalies.Length);
            for (int i = 0; i < allAnomaliesCount; i++)
            {
                int roomIndex = Random.Range(0, rooms.Length);
                if (rooms[roomIndex].Camera.gameObject.activeSelf) continue;
                
                int anomalyIndex = Random.Range(0, rooms[roomIndex].Anomalies.Length);
                if (rooms[roomIndex].Anomalies[anomalyIndex].IsCasted()) continue;
                
                rooms[roomIndex].Anomalies[anomalyIndex].CastAnomaly();
                return;
            }
        }

        private void FixSpottedAnomaly(IAnomaly spottedAnomaly)
        {
            foreach (var room in rooms)
            {
                foreach (var anomaly in room.Anomalies)
                {
                    if (anomaly.Equals(spottedAnomaly)) anomaly.FixAnomaly();
                }
            }
        }
    }
}