using CrazyRacing.Model;
using UnityEngine;

public class VehiclePresenterRoot : MonoBehaviour
{
    [SerializeField] private VehiclesPoolSetup _vehiclesPoolSetup;
    [SerializeField] private RecoveryVehicleSetup _RecoveryVehicleSetup;

    private VehiclesPool _vehiclesPool;
    private RecoveryVehicle _recoveryVehicle;
    private VehicleInputRouter _vehicleInputRouter;

    private void Start()
    {
        Init();
        _vehicleInputRouter = new VehicleInputRouter(_recoveryVehicle, _vehiclesPool);
        _vehicleInputRouter.Enable();
    }

    private void OnEnable()
    {
        if (_vehicleInputRouter != null)
            _vehicleInputRouter.Enable();
    }

    private void OnDisable()
    {
        _vehicleInputRouter.Disable();
    }

    private void Init()
    {
        _vehiclesPool = _vehiclesPoolSetup.Model;
        _recoveryVehicle = _RecoveryVehicleSetup.Model;
    }
}
