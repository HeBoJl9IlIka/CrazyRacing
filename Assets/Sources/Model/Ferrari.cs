using System;

namespace CrazyRacing.Model
{
    public class Ferrari : IVehicle
    {
        public string Name => Config.Ferrari;

        public void Init()
        {

        }

        public void Enable()
        {

        }

        public void Disable()
        {

        }

        public void Recover(Point recoveryPoint)
        {
            //transform.position = recoveryPoint.transform.position;
            //transform.rotation = recoveryPoint.transform.rotation;
        }
    }
}
