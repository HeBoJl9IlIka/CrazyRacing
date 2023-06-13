using CrazyRacing.Model;
using UnityEngine;

[RequireComponent(typeof(LevelOpenerView))]
public class LevelOpenerSetup : MonoBehaviour
{
    private LevelOpenerView _view;
    private LevelOpener _model;
    private LevelOpenerPresenter _presenter;

    public LevelOpener Model => _model;

    private void Awake()
    {
        _view = GetComponent<LevelOpenerView>();
        _model = new LevelOpener();
        _presenter = new LevelOpenerPresenter(_view, _model);
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
