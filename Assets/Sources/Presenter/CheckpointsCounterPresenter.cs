using CrazyRacing.Model;

public class CheckpointsCounterPresenter
{
    private CheckpointsCounterView _counterView;
    private ProgressBarView _progressBarView;
    private CheckpointsCounter _model;

    public CheckpointsCounterPresenter(CheckpointsCounterView view, CheckpointsCounter model, ProgressBarView progressBarView)
    {
        _counterView = view;
        _model = model;
        _progressBarView = progressBarView;
    }

    public void Enable()
    {
        _counterView.Passing += OnPassing;
        _model.Passed += OnPassedCheckpoint;
    }

    public void Disable()
    {
        _counterView.Passing -= OnPassing;
        _model.Passed -= OnPassedCheckpoint;
    }

    private void OnPassing(CheckpointView checkpoint)
    {
        _model.CountCheckpoint(checkpoint);
    }

    private void OnPassedCheckpoint(CheckpointView checkpoint, int currentNumber)
    {
        _counterView.ChangeCheckpoint(checkpoint);
        _progressBarView.Add(currentNumber);
    }
}
