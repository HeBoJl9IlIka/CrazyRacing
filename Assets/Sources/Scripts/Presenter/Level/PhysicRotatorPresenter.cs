using CrazyRacing.Model;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicRotatorPresenter : MonoBehaviour
{
    private const float _speedRotate = 1000f;

    [SerializeField] private List<Rotator.Axis> _axes;
    [SerializeField] private float _maxAngularVelocity = 1f;

    private Vector3 _direction;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _direction = Rotator.GetDirection(_axes.ToArray());
        _maxAngularVelocity += Random.Range(Config.BarrierMinAngularVelocity, Config.BarrierMaxAngularVelocity);
        _rigidbody.maxAngularVelocity = _maxAngularVelocity;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddRelativeTorque(_direction * _speedRotate * Time.deltaTime, ForceMode.VelocityChange);
    }
}
