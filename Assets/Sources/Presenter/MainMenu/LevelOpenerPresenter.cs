using CrazyRacing.Model;

public class LevelOpenerPresenter
{
    private LevelOpenerView _view;
    private LevelOpener _model;

    public LevelOpenerPresenter(LevelOpenerView view, LevelOpener model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _model.Opening += OnOpening;
    }

    public void Disable()
    {
        _model.Opening -= OnOpening;
    }

    private void OnOpening(int number)
    {
        _view.OpenLevel(number);
    }
}
