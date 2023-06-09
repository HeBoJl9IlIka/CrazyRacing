using System;

namespace CrazyRacing.Model
{
    public class RecoveryVehicle
    {
        public event Action<VehicleView> Recovering;

        public void Recover(VehicleView vehicle)
        {
            Recovering?.Invoke(vehicle);
        }
    }
}
