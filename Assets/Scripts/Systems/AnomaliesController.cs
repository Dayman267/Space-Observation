using Objects;
using UnityEngine;
using Zenject;

namespace Systems
{
    public sealed class AnomaliesController : IInitializable, ITickable
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
            int roomIndex = Random.Range(0, rooms.Length);
            if (!rooms[roomIndex].Camera.gameObject.activeSelf)
            {
                int anomalyIndex = Random.Range(0, rooms[roomIndex].Anomalies.Length);
                if (!rooms[roomIndex].Anomalies[anomalyIndex].IsCasted())
                    rooms[roomIndex].Anomalies[anomalyIndex].CastAnomaly();
                else TriggerAnomaly();
            }
        }

        private void FixAnomaly()
        {
            //TODO
        }
    }
}