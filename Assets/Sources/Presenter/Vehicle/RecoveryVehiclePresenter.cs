using CrazyRacing.Model;

public class RecoveryVehiclePresenter
{
    private readonly SkippingLevelView _skippingLevelView;
    private readonly RecoveryVehicleView _recoveryVehicleView;
    private readonly RecoveryVehicle _model;

    public RecoveryVehiclePresenter(SkippingLevelView skippingLevelView, RecoveryVehicleView recoveryVehicleView, RecoveryVehicle model)
    {
        _skippingLevelView = skippingLevelView;
        _recoveryVehicleView = recoveryVehicleView;
        _model = model;
    }

    public void Enable()
    {
        _model.Recovering += OnRecovering;
        _model.MaxRecovered += OnMaxRecovered;
    }

    public void Disable()
    {
        _model.Recovering -= OnRecovering;
        _model.MaxRecovered -= OnMaxRecovered;
    }

    private void OnRecovering(VehicleView vehicle)
    {
        _recoveryVehicleView.Recover(vehicle);
    }

    private void OnMaxRecovered()
    {
        _skippingLevelView.ShowMenu();
    }
}
