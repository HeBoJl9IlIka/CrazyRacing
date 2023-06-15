using CrazyRacing.Model;
using UnityEngine;
using System.Collections.Generic;

public class LevelRoot : MonoBehaviour
{
    [SerializeField] private CreatorVehicle[] _vehicleCreators;
    [SerializeField] private VehiclePresenterFactory _vehiclePresenterFactory;
    [SerializeField] private CheckpointPresenterFactory _checkpointPresenterFactory;
    [SerializeField] private PresentersFactory _presenterFactory;
    [SerializeField] private RecoveryPointPresenter _recoveryPointPresenter;
    [SerializeField] private BorderPresenter _borderPresenter;
    [SerializeField] private ProgressBarPresenter _progressBarPresenter;

    private VehicleInputRouter _vehicleInputRouter;
    private VehiclesPool _vehiclesPool;
    private VehicleRecovery _vehicleRecovery;
    private CheckpointsCounter _checkpointsCounter;
    private PauseGame _pauseGame;
    private PauseGame _completedMenu;
    private PauseGame _skippingMenu;
    private List<Vehicle> _vehicles = new List<Vehicle>();
    private List<Checkpoint> _checkpoints = new List<Checkpoint>();

    private void Awake()
    {
        foreach (var creator in _vehicleCreators)
            _vehicles.Add(creator.Create());

        _vehicleInputRouter = new VehicleInputRouter();
        _vehiclesPool = new VehiclesPool(_vehicles.ToArray());
        _vehicleRecovery = new VehicleRecovery();
        _checkpointsCounter = new CheckpointsCounter(_checkpointPresenterFactory.AmountCheckpoints);
        _pauseGame = new PauseGame();
        _completedMenu = new PauseGame();
        _skippingMenu = new PauseGame();
        _presenterFactory.CreatePauseGame(_pauseGame);
        _presenterFactory.CreateCompletedMenu(_completedMenu);
        _presenterFactory.CreateSkippingMenu(_skippingMenu);
    }

    private void Start()
    {
        _vehiclesPool.CreateVehicles();
        _vehiclesPool.EnableFirstVehicle();
        _checkpointsCounter.Init();
        _progressBarPresenter.Init(_checkpoints.Count);
        Subscribe();
    }

    private void OnEnable()
    {
        _vehicleInputRouter.Enable();
        _vehiclesPool.CreatedVehicle += OnCreatedVehicle;
        _vehicleInputRouter.Recovered += OnRecovered;
        _vehicleInputRouter.RotatingVertical += OnRotatingVertical;
        _vehicleInputRouter.RotatingHorizontal += OnRotatingHorizontal;
        _vehicleRecovery.MaxRecovered += OnMaxRecovered;
        _vehicleInputRouter.PausedGame += OnPausedGame;
        _checkpointsCounter.CreatedCheckpoint += OnCreatedCheckpoint;
        _checkpointsCounter.LevelCompleted += OnLevelCompleted;
        _borderPresenter.Fell += OnRecovered;
    }

    private void OnDisable()
    {
        foreach (var checkpoint in _checkpoints)
            checkpoint.Passed -= OnPassed;

        _vehicleInputRouter.Disable();
        _vehiclesPool.CreatedVehicle -= OnCreatedVehicle;
        _vehicleInputRouter.Recovered -= OnRecovered;
        _vehicleInputRouter.RotatingVertical -= OnRotatingVertical;
        _vehicleInputRouter.RotatingHorizontal -= OnRotatingHorizontal;
        _vehicleRecovery.MaxRecovered -= OnMaxRecovered;
        _vehicleInputRouter.PausedGame -= OnPausedGame;
        _checkpointsCounter.CreatedCheckpoint -= OnCreatedCheckpoint;
        _checkpointsCounter.LevelCompleted -= OnLevelCompleted;
        _borderPresenter.Fell -= OnRecovered;
    }

    private void OnCreatedCheckpoint(Checkpoint checkpoint, int index)
    {
        _checkpoints.Add(checkpoint);
        _checkpointPresenterFactory.InitPresenter(checkpoint, index);
    }

    private void OnPassed(Checkpoint checkpoint, Vehicle vehicle)
    {
        OnRecovered();
        ChangeVehicle();
        _checkpointsCounter.CountCheckpoint();
        _checkpointsCounter.ChangeCheckpoint(checkpoint);
        _progressBarPresenter.Add();
    }

    private void OnLevelCompleted()
    {
        _completedMenu.Pause();
    }

    private void Subscribe()
    {
        foreach (var checkpoint in _checkpoints)
            checkpoint.Passed += OnPassed;
    }

    private void ChangeVehicle()
    {
        _vehiclesPool.ChangeVehicle();
    }

    private void OnRecovered()
    {
        Vector3 position = _recoveryPointPresenter.transform.position;
        Vector3 rotation = _recoveryPointPresenter.transform.eulerAngles;
        _vehicleRecovery.Recover(_vehiclesPool.Current, position, rotation);
    }

    private void OnCreatedVehicle(Vehicle vehicle)
    {
        _vehiclePresenterFactory.Create(vehicle);
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

    private void OnMaxRecovered()
    {
        _skippingMenu.Pause();
    }

    private void OnPausedGame()
    {
        _pauseGame.Execute();
    }
}

public abstract class CreatorVehicle : MonoBehaviour
{
    public abstract Vehicle Create();
}