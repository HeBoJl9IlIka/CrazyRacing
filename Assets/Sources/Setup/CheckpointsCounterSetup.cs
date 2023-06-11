using CrazyRacing.Model;
using UnityEngine;

public class CheckpointsCounterSetup : MonoBehaviour
{
    [SerializeField] private CheckpointsCounterView _counterView;
    [SerializeField] private ProgressBarView _progressBarView;

    private CheckpointsCounter _model;
    private CheckpointsCounterPresenter _presenter;

    public CheckpointsCounter Model => _model;

    private void Awake()
    {
        _model = new CheckpointsCounter(_counterView.AmountCheckpoints);
        _presenter = new CheckpointsCounterPresenter(_counterView, _model, _progressBarView);
        _progressBarView.Init(_counterView.AmountCheckpoints);
    }

    private void OnEnable()
    {
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }
}
