using CrazyRacing.Model;
using System.Collections.Generic;
using UnityEngine;

public class VehicleRoot : MonoBehaviour
{
    [SerializeField] private VehiclePresenterFactory _vehiclePresenterFactory;
    [SerializeField] private RecoveryPointPresenter _recoveryPointPresenter;
    [SerializeField] private CreatorVehicle[] _vehicleCreators;

    private VehiclesPool _vehiclesPool;
    private List<Vehicle> _vehicles = new List<Vehicle>();
    private VehicleInputRouter _vehicleInputRouter;
    private VehicleRecovery _vehicleRecovery;

    private void Awake()
    {
        foreach (var creator in _vehicleCreators)
            _vehicles.Add(creator.Create());

        _vehiclesPool = new VehiclesPool(_vehicles.ToArray());
        _vehicleInputRouter = new VehicleInputRouter();
        _vehicleRecovery = new VehicleRecovery();
    }

    private void Start()
    {
        _vehiclesPool.CreateVehicles();
        _vehiclesPool.EnableFirstVehicle();
    }

    private void OnEnable()
    {
        _vehicleInputRouter.Enable();
        _vehiclesPool.CreatedVehicle += OnCreatedVehicle;
        _vehicleInputRouter.Recovered += OnRecovered;
        _vehicleInputRouter.RotatingVertical += OnRotatingVertical;
        _vehicleInputRouter.RotatingHorizontal += OnRotatingHorizontal;
    }

    private void OnDisable()
    {
        _vehicleInputRouter.Disable();
        _vehiclesPool.CreatedVehicle -= OnCreatedVehicle;
        _vehicleInputRouter.Recovered -= OnRecovered;
        _vehicleInputRouter.RotatingVertical -= OnRotatingVertical;
        _vehicleInputRouter.RotatingHorizontal -= OnRotatingHorizontal;
    }

    private void OnCreatedVehicle(Vehicle vehicle)
    {
        _vehiclePresenterFactory.Create(vehicle);
    }

    private void OnRecovered()
    {
        Vector3 position = _recoveryPointPresenter.transform.position;
        Vector3 rotation = _recoveryPointPresenter.transform.eulerAngles;
        _vehicleRecovery.Recover(_vehiclesPool.Current, position, rotation);
    }

    private void OnRotatingVertical(float direction)
    {
        Vehicle vehicle = _vehiclesPool.Current;
        vehicle.RotateVertical(direction);
    }

    private void OnRotatingHorizontal(float direction)
    {
        Vehicle vehicle = _vehiclesPool.Current;
        vehicle.RotateHorizontal(direction);
    }
}

public abstract class CreatorVehicle : MonoBehaviour
{
    public abstract Vehicle Create();
}
