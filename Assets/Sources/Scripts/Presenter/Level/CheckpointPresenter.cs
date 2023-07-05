using CrazyRacing.Model;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CheckpointPresenter : MonoBehaviour
{
    private Checkpoint _model;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out VehiclePresenter vehicle))
            _model.Pass(vehicle.Model);
    }

    public void Init(Checkpoint checkpoint)
    {
        _model = checkpoint;
        Subscribe();
    }

    private void OnEnabled()
    {
        gameObject.SetActive(true);
        Invoke(nameof(EnableCollider), Config.DelayEnablingCheckpointCollider);
    }

    private void OnHided()
    {
        gameObject?.SetActive(false);
    }

    private void OnDisabled()
    {
        Unsubscribe();
        gameObject?.SetActive(false);
    }

    private void EnableCollider()
    {
        _boxCollider.enabled = true;
    }

    private void Subscribe()
    {
        _model.Showed += OnEnabled;
        _model.Disabled += OnDisabled;
        _model.Hided += OnHided;
    }
    
    private void Unsubscribe()
    {
        _model.Showed -= OnEnabled;
        _model.Disabled -= OnDisabled;
        _model.Hided -= OnHided;
    }
}
