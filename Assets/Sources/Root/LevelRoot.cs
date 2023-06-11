using CrazyRacing.Model;
using UnityEngine;
using System;

public class LevelRoot : MonoBehaviour
{
    [SerializeField] private VehiclesPoolSetup _vehiclesPoolSetup;
    [SerializeField] private RecoveryVehicleSetup _recoveryVehicleSetup;
    [SerializeField] private CheckpointsCounterSetup _checkpointsCounterSetup;

    private VehiclesPool _vehiclesPool;
    private RecoveryVehicle _recoveryVehicle;
    private CheckpointsCounter _checkpointsCounter;
    private VehicleInputRouter _vehicleInputRouter;

    private void Start()
    {
        Init();

        if (_vehiclesPool.AmountVehicles != _checkpointsCounter.AmountCheckpoints)
            throw new ArgumentOutOfRangeException();

        _vehicleInputRouter = new VehicleInputRouter(_recoveryVehicle, _vehiclesPool);
        OnEnable();
    }

    private void OnEnable()
    {
        if (_vehicleInputRouter != null)
            _vehicleInputRouter.Enable();

        if(_checkpointsCounter != null)
            _checkpointsCounter.Passed += OnPassed;
    }

    private void OnDisable()
    {
        _vehicleInputRouter.Disable();

        _checkpointsCounter.Passed += OnPassed;
    }

    private void Init()
    {
        _vehiclesPool = _vehiclesPoolSetup.Model;
        _recoveryVehicle = _recoveryVehicleSetup.Model;
        _checkpointsCounter = _checkpointsCounterSetup.Model;
    }

    private void OnPassed(CheckpointView checkpoint, int currentNumber)
    {
        _vehiclesPool.ChangeVehicle();
    }
}
