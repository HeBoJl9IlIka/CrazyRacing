using CrazyRacing.Model;

public class ProgressBarPresenter
{
    private ProgressBarView _view;
    private CheckpointsCounter _model;

    public ProgressBarPresenter(ProgressBarView view, CheckpointsCounter model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _model.Passed += OnPassedCheckpoint;
    }

    public void Disable()
    {
        _model.Passed -= OnPassedCheckpoint;
    }

    private void OnPassedCheckpoint(CheckpointPresenter checkpoint, int currentNumber)
    {
        _view.Add(currentNumber);
    }
}
