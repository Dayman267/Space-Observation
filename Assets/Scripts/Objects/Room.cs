using UnityEngine;

namespace Objects
{
    public sealed class Room
    {
        private readonly Camera camera;
        private readonly IAnomaly[] anomalies;

        public Camera Camera => camera;
        public IAnomaly[] Anomalies => anomalies;

        public Room(Camera camera, IAnomaly[] anomalies)
        {
            this.camera = camera;
            this.anomalies = anomalies;
        }
    }
}