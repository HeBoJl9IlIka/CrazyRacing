using CrazyRacing.Model;

public class VehicleRotatorPresenter
{
    private readonly VehicleRotator _model;
    private readonly VehicleRotatorView _view;

    public VehicleRotatorPresenter(VehicleRotatorView view, VehicleRotator model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _model.RotatingVertical += OnRotatingVertical;
        _model.RotatingHorizontal += OnRotatingHorizontal;
    }

    public void Disable()
    {
        _model.RotatingVertical -= OnRotatingVertical;
        _model.RotatingHorizontal -= OnRotatingHorizontal;
    }

    private void OnRotatingVertical(float direction)
    {
        _view.RotateVertical(direction);
    }

    private void OnRotatingHorizontal(float direction)
    {
        _view.RotateHorizontal(direction);
    }
}