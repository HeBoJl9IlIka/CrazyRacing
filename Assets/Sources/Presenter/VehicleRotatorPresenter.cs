using UnityEngine;
using UnityEngine.InputSystem.HID;

public class VehicleRotatorPresenter : LevelPresenter
{
    private LevelRoot _levelRoot;
    private bool _isRoad;

    public override void Init(LevelRoot levelRoot)
    {
        _levelRoot = levelRoot;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("EnterTrigger");
    //}

    [SerializeField] private LayerMask _layerMask;
    //private RaycastHit _raycastHit;

    private void FixedUpdate()
    {
        RaycastHit _raycastHit;

        if (Physics.Raycast(transform.position, Vector3.down, out _raycastHit, 100, _layerMask))
        {
            Debug.Log(_raycastHit.collider.gameObject);
            Debug.DrawRay(transform.position, Vector3.down * 2, Color.red);
        }
    }
}