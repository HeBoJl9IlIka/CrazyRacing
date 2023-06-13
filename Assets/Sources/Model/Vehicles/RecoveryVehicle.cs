using System;

namespace CrazyRacing.Model
{
    public class RecoveryVehicle
    {
        private const int MaxAmountRecovery = 2;

        private int _amountRecovery;

        public event Action<VehicleView> Recovering;
        public event Action MaxRecovered;

        public void Recover(VehicleView vehicle)
        {
            Recovering?.Invoke(vehicle);
            ++_amountRecovery;

            if (_amountRecovery >= MaxAmountRecovery)
            {
                _amountRecovery = 0;
                MaxRecovered?.Invoke();
            }
        }
    }
}
