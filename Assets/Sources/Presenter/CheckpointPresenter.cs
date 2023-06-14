using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CheckpointPresenter : MonoBehaviour
{
    public event Action<VehiclePresenter> Passed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out VehiclePresenter vehicle))
            Passed?.Invoke(vehicle);
    }
}
