using UnityEngine;

public class RecoveryVehicleView : MonoBehaviour
{
    [SerializeField] private RecoveryPoint _recoveryPoint;

    public void Recover(VehicleView vehicle)
    {
        vehicle.transform.position = _recoveryPoint.transform.position;
        vehicle.transform.rotation = _recoveryPoint.transform.rotation;
    }
}
