using CrazyRacing.Model;
using UnityEngine;
using System;

public class LevelRoot : MonoBehaviour
{
    [SerializeField] private VehiclesPoolSetup _vehiclesPoolSetup;
    [SerializeField] private RecoveryVehicleSetup _recoveryVehicleSetup;
    [SerializeField] private CheckpointsCounterSetup _checkpointsCounterSetup;
    [SerializeField] private ButtonMainMenuView _buttonMainMenuView;
    [SerializeField] private ButtonNextLevelView _buttonNextLevelView;
    [SerializeField] private ButtonSkipLevelView _buttonSkipLevelView;
    [SerializeField] private int _numberLevel;

    private VehiclesPool _vehiclesPool;
    private RecoveryVehicle _recoveryVehicle;
    private CheckpointsCounter _checkpointsCounter;
    private VehicleInputRouter _vehicleInputRouter;
    private ProgressGame _progressGame = new ProgressGame();
    private SceneOpener _sceneOpener = new SceneOpener();
    private int _numberNextLevel;

    private void Start()
    {
        _numberNextLevel = _numberLevel + 1;
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

        _buttonMainMenuView.onClick.AddListener(OnClickMainMenu);
        _buttonNextLevelView.onClick.AddListener(OnClickNextLevel);
        _buttonSkipLevelView.onClick.AddListener(OnClickSkipLevel);
    }

    private void OnDisable()
    {
        if (_vehicleInputRouter != null)
            _vehicleInputRouter.Disable();

        if (_checkpointsCounter != null)
        {
            _checkpointsCounter.Passed -= OnPassed;
            _checkpointsCounter.LevelCompleted -= OnLevelCompleted;
        }

        _buttonMainMenuView.onClick.RemoveListener(OnClickMainMenu);
        _buttonNextLevelView.onClick.RemoveListener(OnClickNextLevel);
        _buttonSkipLevelView.onClick.RemoveListener(OnClickSkipLevel);
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
            _progressGame.SaveProgress(_numberNextLevel);
    }

    private void OnClickSkipLevel()
    {
        OnLevelCompleted();
        _sceneOpener.OpenScene(_numberNextLevel);
    }

    private void OnClickMainMenu()
    {
        _sceneOpener.OpenScene(0);
    }

    private void OnClickNextLevel()
    {
        _sceneOpener.OpenScene(_numberNextLevel);
    }
}