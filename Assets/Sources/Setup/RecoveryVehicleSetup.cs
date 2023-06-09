using CrazyRacing.Model;
using UnityEngine;

public class RecoveryVehicleSetup : MonoBehaviour
{
    [SerializeField] private RecoveryVehicleView _view;

    private RecoveryVehicle _model;
    private RecoveryVehiclePresenter _presenter;

    public RecoveryVehicle Model => _model;
    public RecoveryVehiclePresenter Presenter => _presenter;

    private void Awake()
    {
        _model = new RecoveryVehicle();
        _presenter = new RecoveryVehiclePresenter(_view, _model);
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
