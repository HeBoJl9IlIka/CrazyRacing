using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CheckpointView : MonoBehaviour
{
    public event Action<CheckpointView> Passed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out VehicleView vehicle))
            Passed?.Invoke(this);
    }
}
