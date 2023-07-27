using CrazyRacing.Model;
using System.Collections.Generic;
using UnityEngine;

public class RotatorPresenter : MonoBehaviour
{

    [SerializeField] private List<Rotator.Axis> _axes;
    [SerializeField] private float _speedRotate;

    private Vector3 _direction;

    private void Awake()
    {
        _direction = Rotator.GetDirection(_axes.ToArray());
    }

    private void FixedUpdate()
    {
        transform.Rotate(_direction * _speedRotate * Time.deltaTime);
    }
}
