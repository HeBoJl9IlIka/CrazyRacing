using CrazyRacing.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

public class VehiclesPoolPresenter
{
    private readonly VehiclesPoolView _view;
    private readonly VehiclesPool _model;

    private VehicleView _lastVehicle;
    private VehicleView _currentVehicle;

    public VehiclesPoolPresenter(VehiclesPoolView view, VehiclesPool model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _model.EnablingVehicle += OnEnablingVehicle;
        _model.DisablingVehicle += OnDisablingVehicle;
        _model.RelocatingVehicle += OnRelocatingVehicle;
    }

    public void Disable()
    {
        _model.EnablingVehicle -= OnEnablingVehicle;
        _model.DisablingVehicle -= OnDisablingVehicle;
        _model.RelocatingVehicle -= OnRelocatingVehicle;
    }

    private void OnDisablingVehicle(VehicleView vehicle)
    {
        _lastVehicle = vehicle;
        _view.DisableVehicle(vehicle);
    }

    private void OnEnablingVehicle(VehicleView vehicle)
    {
        _currentVehicle = vehicle;
        _view.EnableVehicle(vehicle);
    }

    private void OnRelocatingVehicle()
    {
        if (_lastVehicle == null)
            throw new ArgumentNullException(nameof(_lastVehicle));

        if(_currentVehicle == null)
            throw new ArgumentNullException(nameof(_currentVehicle));

        _view.RelocateVehicle(_lastVehicle, _currentVehicle);
    }
}

