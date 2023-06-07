namespace CrazyRacing.Model
{
    public class VehiclesPool
    {
        private VehiclePresenter[] _vehicles;
        private VehiclePresenter _current;

        public VehiclePresenter Current => _current;

        public VehiclesPool(VehiclePresenter[] vehicles)
        {
            _vehicles = vehicles;
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

        public void EnableFirstVehicle()
        {
            _current = _vehicles[0];
            _current.gameObject.SetActive(true);
        }
    }
}
