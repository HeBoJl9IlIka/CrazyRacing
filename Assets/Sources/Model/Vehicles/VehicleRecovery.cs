using System;

namespace CrazyRacing.Model
{
    public class VehicleRecovery
    {
        private const int MaxAmountRecovery = 2;

        private int _amountRecovery;

        //public event Action<Vehicle> Recovering;
        public event Action MaxRecovered;

        public void Recover(Ferrari vehicle, Point recoveryPoint)
        {
            vehicle.Recover(recoveryPoint);

            //Recovering?.Invoke(vehicle);
            ++_amountRecovery;

            if (_amountRecovery >= MaxAmountRecovery)
            {
                _amountRecovery = 0;
                MaxRecovered?.Invoke();
            }
        }
    }
}
