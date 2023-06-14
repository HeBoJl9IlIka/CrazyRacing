using CrazyRacing.Model;
using UnityEngine;

public class VehiclePresenter : MonoBehaviour
{
    private IVehicle _model;

    public virtual string VehicleName { get; }

    public void Init(IVehicle model)
    {
        _model = model;
    }
}
