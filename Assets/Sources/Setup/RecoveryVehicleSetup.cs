using CrazyRacing.Model;
using UnityEngine;

public class RecoveryVehicleSetup : MonoBehaviour
{
    [SerializeField] private RecoveryVehicleView _recoveryVehicleView;
    [SerializeField] private SkippingLevelView _skippingLevelView;

    private RecoveryVehicle _model;
    private RecoveryVehiclePresenter _presenter;

    public RecoveryVehicle Model => _model;

    private void Awake()
    {
        _model = new RecoveryVehicle();
        _presenter = new RecoveryVehiclePresenter(_skippingLevelView, _recoveryVehicleView, _model);
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
