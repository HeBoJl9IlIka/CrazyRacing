using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleRotatorView : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 1;

    private Rigidbody _rigidbody;
    private Vector3 _vertical;
    private Vector3 _horizontal;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_isGrounded)
            return;

        _rigidbody.maxAngularVelocity = _maxSpeed;
        _rigidbody.AddRelativeTorque(_vertical, ForceMode.VelocityChange);
        _rigidbody.AddRelativeTorque(_horizontal, ForceMode.VelocityChange);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out RoadView road))
            _isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isGrounded = false;
    }

    public void RotateVertical(Vector3 vector)
    {
        _vertical = vector;
    }

    public void RotateHorizontal(Vector3 vector)
    {
        _horizontal = vector;
    }
}
