using UnityEngine;

namespace MVVM
{
    public class VehiclePool
    {
        private Vehicle[] _vehicles;
        private Vehicle _current;

        public Vehicle Current => _current;

        public VehiclePool(Vehicle[] vehicles)
        {
            _vehicles = vehicles;
            DisableAllVehicles();
            EnableFirstVehicle();
        }

        public void ChangeVehicle()
        {
            if (_current == _vehicles[^1])
                return;

            for (int i = 0; i < _vehicles.Length; i++)
            {
                if (_vehicles[i] == _current)
                {
                    _current.gameObject.SetActive(false);
                    _current = _vehicles[++i];
                    _current.gameObject.SetActive(true);
                }
            }
        }

        private void DisableAllVehicles()
        {
            foreach (var vehicle in _vehicles)
                vehicle.gameObject.SetActive(false);
        }

        private void EnableFirstVehicle()
        {
            _current = _vehicles[0];
            _current.gameObject.SetActive(true);
        }
    }
}
