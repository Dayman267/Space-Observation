using App;
using UnityEngine;
using Zenject;

namespace Systems
{
    public sealed class ExitController : ITickable
    {
        private readonly ApplicationFinisher applicationFinisher;

        public ExitController(ApplicationFinisher applicationFinisher)
        {
            this.applicationFinisher = applicationFinisher;
        }

        void ITickable.Tick()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                applicationFinisher.Finish();
            }
        }
    }
}