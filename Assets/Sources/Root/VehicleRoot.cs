using CrazyRacing.Model;
using System;
using UnityEngine;

public class VehicleRoot : MonoBehaviour
{
    [SerializeField] private VehicleFactory _vehicleFactory;

    private VehiclesPool _vehiclesPool;

    private void Awake()
    {
        Ferrari[] vehicles =
        {
            new Ferrari()
        };

        _vehiclesPool = new VehiclesPool(vehicles);
    }

    private void OnEnable()
    {
        _vehiclesPool.CreatedVehicle += OnCreatedVehicle;
    }

    private void OnDisable()
    {
        _vehiclesPool.CreatedVehicle -= OnCreatedVehicle;
    }

    private void OnCreatedVehicle(Ferrari vehicle)
    {
        throw new NotImplementedException();
    }
}
