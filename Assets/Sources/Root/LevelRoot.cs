using CrazyRacing.Model;
using UnityEngine;
using System;

public class LevelRoot : MonoBehaviour
{
    [SerializeField] private VehiclesPoolSetup _vehiclesPoolSetup;
    [SerializeField] private RecoveryVehicleSetup _recoveryVehicleSetup;
    [SerializeField] private CheckpointsCounterSetup _checkpointsCounterSetup;
    [SerializeField] private int _numberLevel;

    private VehiclesPool _vehiclesPool;
    private RecoveryVehicle _recoveryVehicle;
    private CheckpointsCounter _checkpointsCounter;
    private VehicleInputRouter _vehicleInputRouter;
    private ProgressGame _progressGame = new ProgressGame();

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

        if (_checkpointsCounter != null)
        {
            _checkpointsCounter.Passed += OnPassed;
            _checkpointsCounter.LevelCompleted += OnLevelCompleted;
        }
    }

    private void OnDisable()
    {
        _vehicleInputRouter.Disable();

        _checkpointsCounter.Passed -= OnPassed;
        _checkpointsCounter.LevelCompleted -= OnLevelCompleted;
    }

    private void Init()
    {
        _vehiclesPool = _vehiclesPoolSetup.Model;
        _recoveryVehicle = _recoveryVehicleSetup.Model;
        _checkpointsCounter = _checkpointsCounterSetup.Model;
        _progressGame.Init();
    }

    private void OnPassed(CheckpointView checkpoint, int currentNumber)
    {
        _vehiclesPool.ChangeVehicle();
    }

    private void OnLevelCompleted()
    {
        if (_progressGame.GetNumberCurrentLevel() == _numberLevel)
            _progressGame.SaveProgress(++_numberLevel);
    }
}