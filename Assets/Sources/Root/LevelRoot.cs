using CrazyRacing.Model;
using UnityEngine;

public class LevelRoot : MonoBehaviour
{
    [SerializeField] private VehiclesPoolSetup _vehiclesPoolSetup;
    [SerializeField] private RecoveryVehicleSetup _recoveryVehicleSetup;
    [SerializeField] private CheckpointsCounterSetup _checkpointsCounterSetup;

    private VehiclesPool _vehiclesPool;
    private RecoveryVehicle _recoveryVehicle;
    private CheckpointsCounter _checkpoints—ounter;
    private VehicleInputRouter _vehicleInputRouter;

    private void Start()
    {
        Init();
        _vehicleInputRouter = new VehicleInputRouter(_recoveryVehicle, _vehiclesPool);
        _vehicleInputRouter.Enable();

        _checkpoints—ounter.Passed += OnPassed;
    }

    private void OnEnable()
    {
        if (_vehicleInputRouter != null)
            _vehicleInputRouter.Enable();

    }

    private void OnDisable()
    {
        _vehicleInputRouter.Disable();

        _checkpoints—ounter.Passed += OnPassed;
    }

    private void Init()
    {
        _vehiclesPool = _vehiclesPoolSetup.Model;
        _recoveryVehicle = _recoveryVehicleSetup.Model;
        _checkpoints—ounter = _checkpointsCounterSetup.Model;
    }

    private void OnPassed(CheckpointView checkpoint)
    {
        _vehiclesPool.ChangeVehicle();
    }
}
