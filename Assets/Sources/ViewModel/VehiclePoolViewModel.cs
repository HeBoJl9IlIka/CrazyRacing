using System;
using System.Collections.Generic;
using UnityEngine;

namespace MVVM
{
    public class VehiclePoolViewModel : ViewModel
    {
        [SerializeField] private CheckpointViewModel _checkpointViewModel;
        [SerializeField] private GameObject[] _vehiclesPrefabs;

        [Model] private VehiclePool _vehiclePool;
        private List<Vehicle> _vehicles = new List<Vehicle>();

        private Checkpoint Checkpoint => _checkpointViewModel.Checkpoint;

        public Vehicle CurrentVehicle => _vehiclePool.Current;

        private void Awake()
        {
            if (_vehiclesPrefabs.Length == 0)
                throw new ArgumentNullException(nameof(_vehiclesPrefabs));

            CreateVehicles();
            _vehiclePool = new VehiclePool(_vehicles.ToArray());
        }

        private void OnEnable()
        {
            Checkpoint.Passed += OnPassed;
        }

        private void OnDisable()
        {
            Checkpoint.Passed -= OnPassed;
        }

        [Command]
        private void OnPassed(Transform transform) => _vehiclePool.ChangeVehicle();

        private void CreateVehicles()
        {
            foreach (var vehicle in _vehiclesPrefabs)
            {
                if (vehicle.TryGetComponent(out Vehicle component) == false)
                    throw new ArgumentNullException(nameof(vehicle));

                GameObject newVehicle = Instantiate(vehicle, transform);
                _vehicles.Add(newVehicle.GetComponent<Vehicle>());
            } 
        }
    }
}
