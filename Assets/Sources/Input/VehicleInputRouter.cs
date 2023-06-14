using CrazyRacing.Model;
using UnityEngine.InputSystem;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class VehicleInputRouter
{
    private readonly VehicleInput _input;
    private readonly VehicleRecovery _recoveryVehicle;
    private readonly VehiclesPool _vehiclesPool;
    private VehicleRotator _vehicleRotator;

    public VehicleInputRouter(VehicleRecovery recoveryVehicle, VehiclesPool vehiclesPool)
    {
        _input = new VehicleInput();
        _recoveryVehicle = recoveryVehicle;
        _vehiclesPool = vehiclesPool;
    }

    public void Enable()
    {
        _input.Enable();
        _input.Vehicle.RecoveredVehicle.performed += OnRecoveredVehicle;
        _input.Vehicle.RotatedHorizontal.started += OnRotatingHorizontal;
        _input.Vehicle.RotatedHorizontal.canceled += OnRotatedHorizontal;
        _input.Vehicle.RotatedVertical.started += OnRotatingVertical;
        _input.Vehicle.RotatedVertical.canceled += OnRotatedVertical;
        //_vehiclesPool.EnablingVehicle += OnEnablingVehicle;
    }

    public void Disable()
    {
        _input.Disable();
        _input.Vehicle.RecoveredVehicle.performed -= OnRecoveredVehicle;
        _input.Vehicle.RotatedHorizontal.started -= OnRotatingHorizontal;
        _input.Vehicle.RotatedHorizontal.canceled -= OnRotatedHorizontal;
        _input.Vehicle.RotatedVertical.started -= OnRotatingVertical;
        _input.Vehicle.RotatedVertical.canceled -= OnRotatedVertical;
        //_vehiclesPool.EnablingVehicle -= OnEnablingVehicle;
    }

    private void OnRecoveredVehicle(InputAction.CallbackContext context)
    {
        //_recoveryVehicle.Recover(_vehiclesPool.Current);
    }

    private void OnRotatingHorizontal(InputAction.CallbackContext context)
    {
        _vehicleRotator.RotateHorizontal(context.ReadValue<float>());
    }

    private void OnRotatedHorizontal(InputAction.CallbackContext context)
    {
        _vehicleRotator.RotateHorizontal(0);
    }

    private void OnRotatingVertical(InputAction.CallbackContext context)
    {
        _vehicleRotator.RotateVertical(context.ReadValue<float>());
    }

    private void OnRotatedVertical(InputAction.CallbackContext context)
    {
        _vehicleRotator.RotateVertical(0);
    }

    private void OnEnablingVehicle(VehicleView vehicle)
    {
        if (vehicle.TryGetComponent(out VehicleRotatorSetup vehicleRotatorSetup) == false)
            throw new ArgumentNullException(nameof(vehicleRotatorSetup));

        //_vehicleRotator = vehicleRotatorSetup.Model;
    }
}
