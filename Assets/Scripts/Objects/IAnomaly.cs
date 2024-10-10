using System;

namespace Objects
{
    public interface IAnomaly
    {
        public void CastAnomaly();
        public bool IsCasted();
        public void FixAnomaly();
    }
}