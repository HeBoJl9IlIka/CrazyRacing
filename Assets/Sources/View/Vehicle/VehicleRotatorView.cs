using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleRotatorView : MonoBehaviour
{
    [SerializeField] private float _force = 5;
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
        _rigidbody.AddRelativeTorque(_vertical * Time.deltaTime * _force, ForceMode.VelocityChange);
        _rigidbody.AddRelativeTorque(_horizontal * Time.deltaTime * _force, ForceMode.VelocityChange);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Road road))
            _isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isGrounded = false;
    }

    public void RotateVertical(float direction)
    {
        _vertical = new Vector3(0, 0, direction);
    }

    public void RotateHorizontal(float direction)
    {
        _horizontal = new Vector3(direction, 0, 0);
    }
}
