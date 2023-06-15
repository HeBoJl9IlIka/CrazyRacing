using UnityEngine.InputSystem;
using System;

public class VehicleInputRouter
{
    private readonly VehicleInput _input;

    public event Action PausedGame;
    public event Action Recovered;
    public event Action<float> RotatingHorizontal;
    public event Action<float> RotatingVertical;

    public VehicleInputRouter()
    {
        _input = new VehicleInput();
    }

    public void Enable()
    {
        _input.Enable();
        _input.Vehicle.PausedGame.performed += OnPausedGame;
        _input.Vehicle.RecoveredVehicle.performed += OnRecoveredVehicle;
        _input.Vehicle.RotatedHorizontal.started += OnRotatingHorizontal;
        _input.Vehicle.RotatedHorizontal.canceled += OnRotatedHorizontal;
        _input.Vehicle.RotatedVertical.started += OnRotatingVertical;
        _input.Vehicle.RotatedVertical.canceled += OnRotatedVertical;
    }

    public void Disable()
    {
        _input.Disable();
        _input.Vehicle.PausedGame.performed -= OnPausedGame;
        _input.Vehicle.RecoveredVehicle.performed -= OnRecoveredVehicle;
        _input.Vehicle.RotatedHorizontal.started -= OnRotatingHorizontal;
        _input.Vehicle.RotatedHorizontal.canceled -= OnRotatedHorizontal;
        _input.Vehicle.RotatedVertical.started -= OnRotatingVertical;
        _input.Vehicle.RotatedVertical.canceled -= OnRotatedVertical;
    }

    private void OnPausedGame(InputAction.CallbackContext obj)
    {
        PausedGame?.Invoke();
    }

    private void OnRecoveredVehicle(InputAction.CallbackContext context)
    {
        Recovered?.Invoke();
    }

    private void OnRotatingHorizontal(InputAction.CallbackContext context)
    {
        RotatingHorizontal?.Invoke(context.ReadValue<float>());
    }

    private void OnRotatedHorizontal(InputAction.CallbackContext context)
    {
        RotatingHorizontal?.Invoke(0);
    }

    private void OnRotatingVertical(InputAction.CallbackContext context)
    {
        RotatingVertical?.Invoke(context.ReadValue<float>());
    }

    private void OnRotatedVertical(InputAction.CallbackContext context)
    {
        RotatingVertical?.Invoke(0);
    }
}
