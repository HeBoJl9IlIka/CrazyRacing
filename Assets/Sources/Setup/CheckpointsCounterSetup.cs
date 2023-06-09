using CrazyRacing.Model;
using UnityEngine;

public class CheckpointsCounterSetup : MonoBehaviour
{
    [SerializeField] private CheckpointsCounterView _view;

    private Checkpoints—ounter _model;
    private CheckpointsCounterPresenter _presenter;

    public Checkpoints—ounter Model => _model;

    private void Awake()
    {
        _model = new Checkpoints—ounter(_view.AmountCheckpoints);
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
