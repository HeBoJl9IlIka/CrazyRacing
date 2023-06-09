using CrazyRacing.Model;
using UnityEngine;

public class VehiclesPoolSetup : MonoBehaviour
{
    [SerializeField] private VehiclesPoolView _vehiclesPoolView;

    private VehiclesPool _model;
    private VehiclesPoolPresenter _presenter;

    public VehiclesPool Model => _model;

    private void Awake()
    {
        _model = new VehiclesPool(_vehiclesPoolView.CreateVehicles());
        _presenter = new VehiclesPoolPresenter(_vehiclesPoolView, _model);
    }

    private void Start()
    {
        _model.EnableFirstVehicle();
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
