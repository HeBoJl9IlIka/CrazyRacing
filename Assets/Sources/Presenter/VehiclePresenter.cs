using UnityEngine;

public class VehiclePresenter : LevelPresenter
{
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
    }
}
