using CrazyRacing.Model;
using UnityEngine;

public class StopperPresenter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out VehiclePresenter vehiclePresenter))
        {
            if (vehiclePresenter.TryGetComponent(out Rigidbody rigidbody))
            {
                if (rigidbody.velocity.magnitude > Config.MinSpeedForBoost)
                    rigidbody.velocity = rigidbody.velocity / Config.StopForce;
            }
        }
    }
}
