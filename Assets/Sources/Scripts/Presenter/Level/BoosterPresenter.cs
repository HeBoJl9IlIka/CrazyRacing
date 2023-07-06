using CrazyRacing.Model;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BoosterPresenter : MonoBehaviour
{
    private AudioSource[] _audioSources;

    private void Awake()
    {
        _audioSources = GetComponents<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 direction = Vector3.forward * Config.BoostForce * Time.deltaTime;

        if (other.TryGetComponent(out VehiclePresenter vehiclePresenter))
        {
            if (vehiclePresenter.TryGetComponent(out Rigidbody rigidbody))
            {
                if (rigidbody.velocity.magnitude > Config.MinSpeedForBoost)
                {
                    rigidbody.AddRelativeForce(direction, ForceMode.VelocityChange);

                    foreach (var audio in _audioSources)
                        audio.Play();
                }
            }
        }
    }
}
