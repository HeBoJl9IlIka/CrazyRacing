using CrazyRacing.Model;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    [SerializeField] private int _numberLevel;
    [SerializeField] private LevelView _view;

    private Levelmain _model;
    private LevelPresenter _presenter;

    public Levelmain Model => _model;

    private void Awake()
    {
        _model = new Levelmain(_numberLevel);
        _presenter = new LevelPresenter(_view, _model);
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
