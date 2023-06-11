using System;
using System.Collections.Generic;
using UnityEngine;

public class VehiclesPoolView : MonoBehaviour
{
    [SerializeField] private VehicleView[] _vehiclesPrefabs;

    private List<VehicleView> _vehicles = new List<VehicleView>();

    private void Start()
    {
        if (_vehiclesPrefabs.Length == 0)
            throw new ArgumentNullException(nameof(_vehiclesPrefabs));

        foreach (var vehicle in _vehiclesPrefabs)
        {
            if (vehicle.TryGetComponent(out VehicleView component) == false)
                throw new ArgumentNullException(nameof(vehicle));
        }
    }

    public void EnableVehicle(VehicleView vehicle)
    {
        vehicle.gameObject.SetActive(true);
    }

    public void DisableVehicle(VehicleView vehicle)
    {
        vehicle.gameObject.SetActive(false);
    }

    public VehicleView[] CreateVehicles()
    {
        foreach (var vehicle in _vehiclesPrefabs)
        {
            VehicleView newVehicle = Instantiate(vehicle, transform);
            _vehicles.Add(newVehicle);
            newVehicle.gameObject.SetActive(false);
        }

        return _vehicles.ToArray();
    }
}
