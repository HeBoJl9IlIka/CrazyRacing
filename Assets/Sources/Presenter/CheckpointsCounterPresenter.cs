using CrazyRacing.Model;

public class CheckpointsCounterPresenter
{
    private CheckpointsCounterView _view;
    private CheckpointsCounter _model;

    public CheckpointsCounterPresenter(CheckpointsCounterView view, CheckpointsCounter model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _view.Passing += OnPassing;
        _model.Passed += OnPassedCheckpoint;
    }

    public void Disable()
    {
        _view.Passing -= OnPassing;
        _model.Passed -= OnPassedCheckpoint;
    }

    private void OnPassing(CheckpointView checkpoint)
    {
        _model.CountCheckpoint(checkpoint);
    }

    private void OnPassedCheckpoint(CheckpointView checkpoint)
    {
        _view.ChangeCheckpoint(checkpoint);
    }
}
