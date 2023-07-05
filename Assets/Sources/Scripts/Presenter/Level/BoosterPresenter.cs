using CrazyRacing.Model;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshRenderer))]
public class BoosterPresenter : MonoBehaviour
{
    [SerializeField] private Color _targetColor;

    private AudioSource[] _audioSources;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _audioSources = GetComponents<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _meshRenderer.material.DOColor(_targetColor, Config.FlashingDuration).SetLoops(-1, LoopType.Yoyo);
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
