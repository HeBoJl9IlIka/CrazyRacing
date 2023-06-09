using CrazyRacing.Input;
using CrazyRacing.Model;
using UnityEngine.InputSystem;

using UnityEngine;

public class VehicleInputRouter
{
    private readonly VehicleInput _input;
    private readonly RecoveryVehicle _recoveryVehicle;
    private readonly VehiclesPool _vehiclesPool;

    public VehicleInputRouter(RecoveryVehicle recoveryVehicle, VehiclesPool vehiclesPool)
    {
        _input = new VehicleInput();
        _recoveryVehicle = recoveryVehicle;
        _vehiclesPool = vehiclesPool;
    }

    public void Enable()
    {
        _input.Enable();
        _input.Vehicle.RecoveredVehicle.performed += OnRecoveredVehicle;
    }

    public void Disable()
    {
        _input.Disable();
        _input.Vehicle.RecoveredVehicle.performed -= OnRecoveredVehicle;
    }

    private void OnRecoveredVehicle(InputAction.CallbackContext obj)
    {
        _recoveryVehicle.Recover(_vehiclesPool.Current);
    }
}
