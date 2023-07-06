using CrazyRacing.Model;
using UnityEngine;

public class StopperPresenter : MonoBehaviour
{
    private AudioSource[] _audioSources;

    private void Awake()
    {
        _audioSources = GetComponents<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out VehiclePresenter vehiclePresenter))
        {
            if (vehiclePresenter.TryGetComponent(out Rigidbody rigidbody))
            {
                if (rigidbody.velocity.magnitude > Config.MinSpeedForBoost)
                {
                    rigidbody.velocity = rigidbody.velocity / Config.StopForce;

                    foreach (var audio in _audioSources)
                        audio.Play();
                }
            }
        }
    }
}
