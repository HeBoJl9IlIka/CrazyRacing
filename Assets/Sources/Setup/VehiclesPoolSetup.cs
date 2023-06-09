using CrazyRacing.Model;
using UnityEngine;

public class VehiclesPoolSetup : MonoBehaviour
{
    [SerializeField] private VehiclesPoolView _view;

    private VehiclesPool _model;
    private VehiclesPoolPresenter _presenter;

    private void Awake()
    {
        _model = new VehiclesPool(_view.CreateVehicles());
        _presenter = new VehiclesPoolPresenter(_view, _model);
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
