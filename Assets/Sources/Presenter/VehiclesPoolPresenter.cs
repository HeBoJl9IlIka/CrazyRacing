using System;
using System.Collections.Generic;
using UnityEngine;

public class VehiclesPoolPresenter : LevelPresenter
{
    [SerializeField] private GameObject[] _vehiclesPrefabs;

    private void Awake()
    {
        if (_vehiclesPrefabs.Length == 0)
            throw new ArgumentNullException(nameof(_vehiclesPrefabs));

        foreach (var vehicle in _vehiclesPrefabs)
        {
            if (vehicle.TryGetComponent(out VehiclePresenter component) == false)
                throw new ArgumentNullException(nameof(vehicle));
        }
    }

    public override VehiclePresenter[] CreateVehicles()
    {
        List<VehiclePresenter> vehicles = new List<VehiclePresenter>();

        foreach (var vehicle in _vehiclesPrefabs)
        {
            GameObject newVehicle = Instantiate(vehicle, transform);
            vehicles.Add(newVehicle.GetComponent<VehiclePresenter>());
            newVehicle.gameObject.SetActive(false);
        }

        return vehicles.ToArray();
    }
}

