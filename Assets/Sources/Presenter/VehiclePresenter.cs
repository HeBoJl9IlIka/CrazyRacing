using CrazyRacing.Model;
using UnityEngine;

public class VehiclePresenter : MonoBehaviour
{
    private Vehicle _model;

    public virtual string VehicleName { get; }

    private void OnEnable()
    {
        _model.Enabled += OnEnabled;
        _model.Disabled += OnDisabled;
    }

    private void OnDisable()
    {
        _model.Enabled -= OnEnabled;
        _model.Disabled -= OnDisabled;
    }

    public void Init(Vehicle model)
    {
        _model = model;
        _model.Enabled += OnEnabled;
    }

    private void OnEnabled()
    {
        gameObject.SetActive(true);
    }

    private void OnDisabled()
    {
        gameObject.SetActive(false);
    }
}
