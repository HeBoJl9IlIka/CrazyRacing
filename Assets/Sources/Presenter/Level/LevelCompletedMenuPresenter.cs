using CrazyRacing.Model;

public class LevelCompletedMenuPresenter
{
    private readonly LevelCompletedMenuView _levelCompletedMenuView;
    private readonly CheckpointsCounter _model;

    public LevelCompletedMenuPresenter(LevelCompletedMenuView view, CheckpointsCounter model)
    {
        _levelCompletedMenuView = view;
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
        _levelCompletedMenuView.gameObject.SetActive(true);
    }
}
