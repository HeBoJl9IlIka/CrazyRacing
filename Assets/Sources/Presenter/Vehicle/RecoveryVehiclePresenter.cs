using CrazyRacing.Model;

public class RecoveryVehiclePresenter
{
    private readonly RecoveryVehicleView _view;
    private readonly RecoveryVehicle _model;

    public RecoveryVehiclePresenter(RecoveryVehicleView view, RecoveryVehicle model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _model.Recovering += OnRecovering;
    }

    public void Disable()
    {
        _model.Recovering -= OnRecovering;
    }

    private void OnRecovering(VehicleView vehicle)
    {
        _view.Recover(vehicle);
    }
}
