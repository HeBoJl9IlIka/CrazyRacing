using CrazyRacing.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

public class VehicleRoot : MonoBehaviour
{
    [SerializeField] private VehiclePresenterFactory _vehiclePresenterFactory;
    [SerializeField] private CreatorVehicle[] _vehicleCreators;

    private VehiclesPool _vehiclesPool;
    private List<Vehicle> _vehicles = new List<Vehicle>();

    private void Awake()
    {
        foreach (var creator in _vehicleCreators)
            _vehicles.Add(creator.Create());

        _vehiclesPool = new VehiclesPool(_vehicles.ToArray());
    }

    private void Start()
    {
        _vehiclesPool.CreateVehicles();
        _vehiclesPool.EnableFirstVehicle();
    }

    private void OnEnable()
    {
        _vehiclesPool.CreatedVehicle += OnCreatedVehicle;
    }

    private void OnDisable()
    {
        _vehiclesPool.CreatedVehicle -= OnCreatedVehicle;
    }

    private void OnCreatedVehicle(Vehicle vehicle)
    {
        _vehiclePresenterFactory.Create(vehicle);
    }
}

public abstract class CreatorVehicle : MonoBehaviour
{
    public abstract Vehicle Create();
}
