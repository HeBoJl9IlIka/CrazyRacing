using CrazyRacing.Model;

public class VehiclesPoolPresenter
{
    private readonly VehiclesPoolView _view;
    private readonly VehiclesPool _model;

    public VehiclesPoolPresenter(VehiclesPoolView vehiclesPoolView, VehiclesPool vehiclesPoolModel)
    {
        _view = vehiclesPoolView;
        _model = vehiclesPoolModel;
    }

    public void Enable()
    {
        _model.EnablingVehicle += OnEnablingVehicle;
        _model.DisablingVehicle += OnDisablingVehicle;
    }

    public void Disable()
    {
        _model.EnablingVehicle -= OnEnablingVehicle;
        _model.DisablingVehicle -= OnDisablingVehicle;
    }

    private void OnDisablingVehicle(VehicleView vehicle)
    {
        _view.DisableVehicle(vehicle);
    }

    private void OnEnablingVehicle(VehicleView vehicle)
    {
        _view.EnableVehicle(vehicle);
    }
}

