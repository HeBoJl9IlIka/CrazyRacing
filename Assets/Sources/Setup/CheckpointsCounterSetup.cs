using CrazyRacing.Model;
using UnityEngine;

public class CheckpointsCounterSetup : MonoBehaviour
{
    [SerializeField] private CheckpointsCounterView _view;

    private CheckpointsCounter _model;
    private CheckpointsCounterPresenter _presenter;

    public CheckpointsCounter Model => _model;

    private void Awake()
    {
        _model = new CheckpointsCounter(_view.AmountCheckpoints);
        _presenter = new CheckpointsCounterPresenter(_view, _model);
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
