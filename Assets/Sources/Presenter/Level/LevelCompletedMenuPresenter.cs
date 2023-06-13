using CrazyRacing.Model;

public class LevelCompletedMenuPresenter
{
    private readonly LevelCompletedMenuView _view;
    private readonly CheckpointsCounter _model;

    public LevelCompletedMenuPresenter(LevelCompletedMenuView view, CheckpointsCounter model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _model.LevelCompleted += OnLevelCompleted;
    }

    public void Disable()
    {
        _model.LevelCompleted -= OnLevelCompleted;
    }

    private void OnLevelCompleted()
    {
        _view.gameObject.SetActive(true);
    }
}
