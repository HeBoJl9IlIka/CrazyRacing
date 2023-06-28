using CrazyRacing.Model;
using UnityEngine;

public class BoosterPresenter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Vector3 direction = Vector3.forward * Config.BoostForce * Time.deltaTime;

        if (other.TryGetComponent(out VehiclePresenter vehiclePresenter))
        {
            if (vehiclePresenter.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddRelativeForce(direction, ForceMode.VelocityChange);
        }
    }
}
