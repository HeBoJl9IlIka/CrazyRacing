using System;

namespace CrazyRacing.Model
{
    public class VehiclesPool
    {
        private readonly VehicleView[] _vehicles;
        private VehicleView _current;
        private VehicleView _last;

        public VehicleView Current => _current;

        public event Action<VehicleView> EnablingVehicle;
        public event Action<VehicleView> DisablingVehicle;

        public VehiclesPool(VehicleView[] vehicles)
        {
            _vehicles = vehicles;
        }

        public void ChangeVehicle()
        {
            if (_current == _vehicles[^1])
                return;

            for (int i = 0; i < _vehicles.Length; i++)
            {
                if (_vehicles[i] == _current)
                {
                    _last = _current;
                    _current = _vehicles[++i];

                    DisablingVehicle?.Invoke(_last);
                    EnablingVehicle?.Invoke(_current);
                }
            }
        }

        public void EnableFirstVehicle()
        {
            _current = _vehicles[0];
            EnablingVehicle?.Invoke(_current);
        }
    }
}
