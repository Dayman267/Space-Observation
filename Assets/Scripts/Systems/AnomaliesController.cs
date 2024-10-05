using Objects;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class AnomaliesController : ITickable
    {
        private IAnomaly[] anomalies;
        private Camera[] cameras;

        [Inject]
        public void Construct(IAnomaly[] anomalies, Camera[] cameras)
        {
            this.anomalies = anomalies;
            this.cameras = cameras;
        }
        
        public void Tick()
        {
            TriggerAnomaly();
        }

        private void TriggerAnomaly()
        {
            anomalies[0].CastAnomaly();
        }
    }
}