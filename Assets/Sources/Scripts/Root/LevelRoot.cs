using CrazyRacing.Model;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

#pragma warning disable CS0162 // Обнаружен недостижимый код

public class LevelRoot : MonoBehaviour
{
    [SerializeField] private CreatorVehicle[] _vehicleCreators;
    [SerializeField] private VehiclePresenterFactory _vehiclePresenterFactory;
    [SerializeField] private CheckpointPresenterFactory _checkpointPresenterFactory;
    [SerializeField] private PresentersFactory _presenterFactory;
    [SerializeField] private RecoveryPointPresenter _recoveryPointPresenter;
    [SerializeField] private BorderPresenter _borderPresenter;

    private VehicleInputRouter _vehicleInputRouter;
    private VehiclesPool _vehiclesPool;
    private VehicleRecovery _vehicleRecovery;
    private CheckpointsCounter _checkpointsCounter;
    private GamePause _pauseMenu;
    private GamePause _completedMenu;
    private GamePause _skippingMenu;
    private List<Vehicle> _vehicles = new List<Vehicle>();
    private List<Checkpoint> _checkpoints = new List<Checkpoint>();
    private ProgressBarPresenter _progressBarPresenter;
    private SkippingLevelPresenter _skippingLevelPresenter;
    private Sdk _sdk;

    [SerializeField] private UnityEvent _levelCompleted;

    private void Awake()
    {
        foreach (var creator in _vehicleCreators)
            _vehicles.Add(creator.Create());

        _vehicleInputRouter = new VehicleInputRouter();
        _vehiclesPool = new VehiclesPool(_vehicles.ToArray());
        _vehicleRecovery = new VehicleRecovery();
        _checkpointsCounter = new CheckpointsCounter(_checkpointPresenterFactory.AmountCheckpoints);
        _pauseMenu = new GamePause();
        _completedMenu = new GamePause();
        _skippingMenu = new GamePause();
        _presenterFactory.CreatePauseMenu(_pauseMenu);
        _presenterFactory.CreateCompletedMenu(_completedMenu);
        _presenterFactory.CreateMusicPresenter();
        _skippingLevelPresenter = _presenterFactory.CreateSkippingMenu(_skippingMenu);
        _sdk = SdkFactory.Sdk;
    }

    private void Start()
    {
        _vehiclesPool.CreateVehicles();
        _vehiclesPool.EnableFirstVehicle();
        _checkpointsCounter.Init();
        _progressBarPresenter = _presenterFactory.CreateProgressBar(_checkpoints.Count);
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
        _skippingLevelPresenter.Skipped += OnSkipped;
        _sdk.ShowedVideoAd += OnShowedVideoAd;
        _sdk.OpenedAd += OnOpenedAd;
        _sdk.ClosedInterstitialAd += OnClosedInterstitialAd;
        _sdk.CrashedInterstitialAd += OnCrashedInterstitialAd;
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
        _skippingLevelPresenter.Skipped -= OnSkipped;
        _sdk.ShowedVideoAd -= OnShowedVideoAd;
        _sdk.OpenedAd -= OnOpenedAd;
        _sdk.ClosedInterstitialAd -= OnClosedInterstitialAd;
        _sdk.ClosedVideoAd -= OnClosedVideoAd;
        _sdk.CrashedInterstitialAd -= OnCrashedInterstitialAd;
        _sdk.CrashedVideoAd -= OnCrashedVideoAd;
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
        ProgressGame.SaveProgress();
        _levelCompleted?.Invoke();
        _progressBarPresenter.gameObject.SetActive(false);

#if !UNITY_WEBGL || UNITY_EDITOR
        return;
#endif

        _sdk.ShowInterstitialAd();
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
        _pauseMenu.Switch();
    }

    private void OnSkipped()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        OnShowedVideoAd();
        OnOpenedAd();
        return;
#endif

        _sdk.ShowVideoAd();
    }

    private void OnShowedVideoAd()
    {
        ProgressGame.SaveProgress();
        _levelCompleted?.Invoke();
        _progressBarPresenter.gameObject.SetActive(false);
    }

    private void OnOpenedAd()
    {
        _completedMenu.Pause();
    }

    private void OnClosedInterstitialAd()
    {
        _completedMenu.Pause();
    }

    private void OnClosedVideoAd()
    {
        _completedMenu.Continue();
    }

    private void OnCrashedInterstitialAd()
    {
        _completedMenu.Pause();
    }

    private void OnCrashedVideoAd()
    {
        _completedMenu.Continue();
    }
}

public abstract class CreatorVehicle : MonoBehaviour
{
    public abstract Vehicle Create();
}