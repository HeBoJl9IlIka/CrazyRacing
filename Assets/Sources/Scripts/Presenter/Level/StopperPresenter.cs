using CrazyRacing.Model;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StopperPresenter : MonoBehaviour
{
    [SerializeField] private Color _targetColor;

    private AudioSource[] _audioSources;
    private MeshRenderer _meshRenderer;
    private Color _defaultColor;

    private void Awake()
    {
        _audioSources = GetComponents<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultColor = _meshRenderer.material.color;
    }

    private void Update()
    {
        if (_meshRenderer.material.color == _defaultColor)
            _meshRenderer.material.DOColor(_targetColor, Config.BoosterFlashingDuration);

        if (_meshRenderer.material.color == _targetColor)
            _meshRenderer.material.DOColor(_defaultColor, Config.BoosterFlashingDuration);
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
