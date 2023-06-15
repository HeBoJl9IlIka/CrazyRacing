using CrazyRacing.Model;
using UnityEngine;
using System.Collections.Generic;

public class LevelRoot : MonoBehaviour
{
    [SerializeField] private VehicleRoot _vehicleRoot;
    [SerializeField] private CheckpointPresenterFactory _checkpointPresenterFactory;
    [SerializeField] private BorderPresenter _borderPresenter;
    [SerializeField] private SkippingLevelPresenter _skippingLevelPresenter;
    [SerializeField] private ProgressBarPresenter _progressBarPresenter;
    [SerializeField] private LevelCompletedMenuPresenter _levelCompletedMenuPresenter;

    private CheckpointsCounter _checkpointsCounter;
    private List<Checkpoint> _checkpoints = new List<Checkpoint>();

    private void Awake()
    {
        _checkpointsCounter = new CheckpointsCounter(_checkpointPresenterFactory.AmountCheckpoints);
    }

    private void Start()
    {
        _checkpointsCounter.Init();
        _progressBarPresenter.Init(_checkpoints.Count);
        SubscribeCheckpoints();
    }

    private void OnEnable()
    {
        _checkpointsCounter.CreatedCheckpoint += OnCreatedCheckpoint;
        _checkpointsCounter.LevelCompleted += OnLevelCompleted;
        _borderPresenter.Fell += OnFell;
    }

    private void OnDisable()
    {
        foreach (var checkpoint in _checkpoints)
            checkpoint.Passed -= OnPassed;

        _checkpointsCounter.CreatedCheckpoint -= OnCreatedCheckpoint;
        _checkpointsCounter.LevelCompleted -= OnLevelCompleted;
        _borderPresenter.Fell -= OnFell;
    }

    public void ShowSkipMenu()
    {
        _skippingLevelPresenter.ShowMenu();
    }

    private void OnCreatedCheckpoint(Checkpoint checkpoint, int index)
    {
        _checkpoints.Add(checkpoint);
        _checkpointPresenterFactory.InitPresenter(checkpoint, index);
    }

    private void OnPassed(Checkpoint checkpoint, Vehicle vehicle)
    {
        _vehicleRoot.OnRecovered();
        _vehicleRoot.ChangeVehicle();
        _checkpointsCounter.CountCheckpoint();
        _checkpointsCounter.ChangeCheckpoint(checkpoint);
        _progressBarPresenter.Add();
    }

    private void OnLevelCompleted()
    {
        _vehicleRoot.StopVehicle();
        _levelCompletedMenuPresenter.ShowMenu();
    }

    private void OnFell(Vehicle vehicle)
    {
        _vehicleRoot.OnRecovered();
    }

    private void SubscribeCheckpoints()
    {
        foreach (var checkpoint in _checkpoints)
            checkpoint.Passed += OnPassed;
    }
}