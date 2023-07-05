using System;

namespace CrazyRacing.Model
{
    public class VehiclesPool 
    {
        private readonly Vehicle[] _vehicles;
        private Vehicle _current;

        public Vehicle Current => _current;

        public event Action<Vehicle> CreatedVehicle;

        public VehiclesPool(Vehicle[] vehicles)
        {
            if (vehicles.Length == 0)
                throw new ArgumentNullException(nameof(vehicles));

            _vehicles = vehicles;
        }

        public void ChangeVehicle()
        {
            if (_current == _vehicles[^1])
                return;

            int index = Array.IndexOf(_vehicles, _current);
            _vehicles[index].Disable();
            _current = _vehicles[++index];
            _current.Enable();
        }

        public void EnableFirstVehicle()
        {
            _current = _vehicles[0];
            _current.Enable();
        }

        public void CreateVehicles()
        {
            foreach (var vehicle in _vehicles)
                CreatedVehicle?.Invoke(vehicle);
        }
    }
}
