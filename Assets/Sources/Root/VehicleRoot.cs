using CrazyRacing.Model;
using System.Collections.Generic;
using UnityEngine;

public class VehicleRoot : MonoBehaviour
{
    //[SerializeField] private VehiclePresenterFactory _vehiclePresenterFactory;
    //[SerializeField] private RecoveryPointPresenter _recoveryPointPresenter;
    //[SerializeField] private CreatorVehicle[] _vehicleCreators;

    //private VehiclesPool _vehiclesPool;
    //private List<Vehicle> _vehicles = new List<Vehicle>();
    //private VehicleInputRouter _vehicleInputRouter;
    //private VehicleRecovery _vehicleRecovery;
    //private bool _isPaused;

    private void Awake()
    {
        //foreach (var creator in _vehicleCreators)
        //    _vehicles.Add(creator.Create());

        //_vehiclesPool = new VehiclesPool(_vehicles.ToArray());
        //_vehicleInputRouter = new VehicleInputRouter();
        //_vehicleRecovery = new VehicleRecovery();
    }

    //private void Start()
    //{
    //    _vehiclesPool.CreateVehicles();
    //    _vehiclesPool.EnableFirstVehicle();
    //}

    private void OnEnable()
    {
        //_vehicleInputRouter.Enable();
        //_vehiclesPool.CreatedVehicle += OnCreatedVehicle;
        //_vehicleInputRouter.Recovered += OnRecovered;
        //_vehicleInputRouter.RotatingVertical += OnRotatingVertical;
        //_vehicleInputRouter.RotatingHorizontal += OnRotatingHorizontal;
        //_vehicleRecovery.MaxRecovered += OnMaxRecovered;
        //_vehicleInputRouter.PausedGame += OnPausedGame;
    }

    private void OnDisable()
    {
        //_vehicleInputRouter.Disable();
        //_vehiclesPool.CreatedVehicle -= OnCreatedVehicle;
        //_vehicleInputRouter.Recovered -= OnRecovered;
        //_vehicleInputRouter.RotatingVertical -= OnRotatingVertical;
        //_vehicleInputRouter.RotatingHorizontal -= OnRotatingHorizontal;
        //_vehicleRecovery.MaxRecovered -= OnMaxRecovered;
        //_vehicleInputRouter.PausedGame -= OnPausedGame;
    }

    //public void ChangeVehicle()
    //{
    //    _vehiclesPool.ChangeVehicle();
    //}

    //public void OnRecovered()
    //{
    //    Vector3 position = _recoveryPointPresenter.transform.position;
    //    Vector3 rotation = _recoveryPointPresenter.transform.eulerAngles;
    //    _vehicleRecovery.Recover(_vehiclesPool.Current, position, rotation);
    //}

    //public void StopVehicle()
    //{
    //    _vehiclesPool.Current.Stop();
    //}

    //private void OnCreatedVehicle(Vehicle vehicle)
    //{
    //    _vehiclePresenterFactory.Create(vehicle);
    //}

    //private void OnRotatingVertical(float direction)
    //{
    //    Vehicle vehicle = _vehiclesPool.Current;
    //    vehicle.RotateVertical(direction);
    //}

    //private void OnRotatingHorizontal(float direction)
    //{
    //    Vehicle vehicle = _vehiclesPool.Current;
    //    vehicle.RotateHorizontal(direction);
    //}

    //private void OnMaxRecovered()
    //{
    //    _levelRoot.ShowSkipMenu();
    //}

    //private void OnPausedGame()
    //{
    //    if (_isPaused)
    //    {
    //        _vehiclesPool.Current.Play();
    //        _levelRoot.HidePauseMenu();
    //        _isPaused = false;
    //    }
    //    else
    //    {
    //        StopVehicle();
    //        _levelRoot.ShowPauseMenu();
    //        _isPaused = true;
    //    }
    //}
}

