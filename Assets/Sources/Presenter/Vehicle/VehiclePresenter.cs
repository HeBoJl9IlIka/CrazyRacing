using CrazyRacing.Model;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehiclePresenter : MonoBehaviour
{
    private Vehicle _model;
    private Rigidbody _rigidbody;
    private Vector3 _vertical;
    private Vector3 _horizontal;
    private bool _isGrounded;

    public virtual string VehicleName { get; }
    public Vehicle Model => _model;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _model.Enabled += OnEnabled;
        _model.Disabled += OnDisabled;
        _model.Recovered += OnRecovered;
        _model.RotatingVertical += OnRotatingVertical;
        _model.RotatingHorizontal += OnRotatingHorizontal;
        _model.Stopped += OnStopped;
    }

    private void OnDisable()
    {
        _model.Enabled -= OnEnabled;
        _model.Disabled -= OnDisabled;
        _model.Recovered -= OnRecovered;
        _model.RotatingVertical -= OnRotatingVertical;
        _model.RotatingHorizontal -= OnRotatingHorizontal;
        _model.Stopped -= OnStopped;
    }

    private void FixedUpdate()
    {
        if (_isGrounded)
            return;

        _rigidbody.AddRelativeTorque(_vertical, ForceMode.VelocityChange);
        _rigidbody.AddRelativeTorque(_horizontal, ForceMode.VelocityChange);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out RoadPresenter road))
            _isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isGrounded = false;
    }

    public void Init(Vehicle model)
    {
        _model = model;
        _model.Enabled += OnEnabled;
    }

    private void OnEnabled()
    {
        gameObject.SetActive(true);
    }

    private void OnDisabled()
    {
        gameObject.SetActive(false);
    }

    private void OnRecovered(Vector3 position, Vector3 rotation)
    {
        transform.position = position;
        transform.eulerAngles = rotation;
        _rigidbody.isKinematic = true;
        _rigidbody.isKinematic = false;
    }

    private void OnRotatingHorizontal(Vector3 vector)
    {
        _vertical = vector;
    }

    private void OnRotatingVertical(Vector3 vector)
    {
        _horizontal = vector;
    }

    private void OnStopped()
    {
        _rigidbody.isKinematic = true;
    }
}
