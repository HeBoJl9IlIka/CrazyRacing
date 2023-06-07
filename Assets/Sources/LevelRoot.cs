using CrazyRacing.Model;
using UnityEngine;

public class LevelRoot : MonoBehaviour
{
    [SerializeField] private LevelPresenter _vehiclesPoolPresenter;
    [SerializeField] private LevelPresenter _checkpointPresenter;
    [SerializeField] private RecoveryPoint _recoveryPoint;

    private VehiclesPool _vehiclePool;
    private RecoveryVehicle _recoveryVehicle;
    private VehicleInputRouter _vehicleInputRouter;

    private void Awake()
    {
        Init();

        VehiclePresenter[] vehicles = _vehiclesPoolPresenter.CreateVehicles();

        _vehiclePool = new VehiclesPool(vehicles);
        _recoveryVehicle = new RecoveryVehicle(_recoveryPoint.transform.position);
        _vehicleInputRouter = new VehicleInputRouter(_recoveryVehicle, _vehiclePool);
    }

    private void OnEnable()
    {
        _vehicleInputRouter.Enable();
    }

    private void OnDisable()
    {
        _vehicleInputRouter.Disable();
    }

    public void PassCheckpoint()
    {
        _vehiclePool.ChangeVehicle();
    }

    private void Init()
    {
        _checkpointPresenter.Init(this);
    }
}
