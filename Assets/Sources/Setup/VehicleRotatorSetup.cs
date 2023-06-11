using CrazyRacing.Model;
using UnityEngine;

public class VehicleRotatorSetup : MonoBehaviour
{
    [SerializeField] private VehicleRotatorView _view;

    private VehicleRotator _model;
    private VehicleRotatorPresenter _presenter;

    public VehicleRotator Model => _model;

    private void Awake()
    {
        _model = new VehicleRotator();
        _presenter = new VehicleRotatorPresenter(_view, _model);
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
