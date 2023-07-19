using CrazyRacing.Model;
using NWH.VehiclePhysics2;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(VehicleController))]
public class VehiclePresenter : MonoBehaviour
{
    private Vehicle _model;
    private Rigidbody _rigidbody;
    private VehicleController _vehicleController;
    private Vector3 _vertical;
    private Vector3 _horizontal;
    private bool _isGrounded;

    private bool IsRotating => _vertical != Vector3.zero || _horizontal != Vector3.zero;

    public virtual string VehicleName { get; }
    public Vehicle Model => _model;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _vehicleController = GetComponent<VehicleController>();
    }

    private void FixedUpdate()
    {
        if (IsRotating)
        {
            if (_isGrounded == false)
                _rigidbody.maxAngularVelocity = Config.MaxAngularVelocity;
            else
                _rigidbody.maxAngularVelocity = Config.DefaultAngularVelocity;
        }

        if (_isGrounded)
            return;

        Vector3 direction = _vertical + _horizontal;
        _rigidbody.AddRelativeTorque(direction, ForceMode.VelocityChange);
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
        enabled = true;
        Subscribe();
    }

    private void OnEnabled()
    {
        gameObject.SetActive(true);
    }

    private void OnDisabled()
    {
        gameObject.SetActive(false);
        Unsubscribe();
    }

    private void OnRecovered(Vector3 position, Vector3 rotation)
    {
        transform.position = position;
        transform.eulerAngles = rotation;
        ResetVelocity();
        _vehicleController.damageHandler.Repair();
    }

    private void OnRotatingHorizontal(Vector3 vector)
    {
        _horizontal = vector;
    }

    private void OnRotatingVertical(Vector3 vector)
    {
        _vertical = vector;
    }

    private void ResetVelocity()
    {
        _rigidbody.isKinematic = true;
        _rigidbody.isKinematic = false;
    }

    private void Subscribe()
    {
        _model.Enabled += OnEnabled;
        _model.Disabled += OnDisabled;
        _model.Recovered += OnRecovered;
        _model.RotatingVertical += OnRotatingVertical;
        _model.RotatingHorizontal += OnRotatingHorizontal;
    }

    private void Unsubscribe()
    {
        _model.Enabled -= OnEnabled;
        _model.Disabled -= OnDisabled;
        _model.Recovered -= OnRecovered;
        _model.RotatingVertical -= OnRotatingVertical;
        _model.RotatingHorizontal -= OnRotatingHorizontal;
    }
}
