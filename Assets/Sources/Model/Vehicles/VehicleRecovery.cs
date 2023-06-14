using System;
using UnityEngine;

namespace CrazyRacing.Model
{
    public class VehicleRecovery
    {
        private int _amountRecovery;

        public event Action MaxRecovered;

        public void Recover(Vehicle vehicle, Vector3 position, Vector3 rotation)
        {
            vehicle.Recover(position, rotation);

            ++_amountRecovery;

            if (_amountRecovery >= Config.MaxAmountRecovery)
            {
                _amountRecovery = 0;
                MaxRecovered?.Invoke();
            }
        }
    }
}
