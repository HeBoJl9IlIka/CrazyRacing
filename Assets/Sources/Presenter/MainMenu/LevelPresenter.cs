using CrazyRacing.Model;

public class LevelPresenter
{
    private LevelView _view;
    private Levelmain _model;

    public LevelPresenter(LevelView view, Levelmain model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _view.Selected += OnSelected;
        _model.Unlocked += OnUnlocked;
    }

    public void Disable()
    {
        _view.Selected -= OnSelected;
        _model.Unlocked += OnUnlocked;
    }

    private void OnSelected()
    {
        _model.Open();
    }

    private void OnUnlocked()
    {
        _view.Unlock();
    }
}
