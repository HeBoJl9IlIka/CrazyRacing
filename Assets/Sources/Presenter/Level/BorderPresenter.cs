using CrazyRacing.Model;
using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BorderPresenter : MonoBehaviour
{
    public event Action<Vehicle> Fell;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out VehiclePresenter vehicle))
            Fell?.Invoke(vehicle.Model);
    }
}
