using CrazyRacing.Model;
using UnityEngine;

public class StopperPresenter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out VehiclePresenter vehiclePresenter))
        {
            if (vehiclePresenter.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.velocity = rigidbody.velocity / Config.StopForce;
        }
    }
}
