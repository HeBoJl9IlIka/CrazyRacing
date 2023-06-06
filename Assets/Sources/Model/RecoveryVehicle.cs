using UnityEngine;

namespace MVVM
{
    public class RecoveryVehicle
    {
        private Vector3 _recoveryPoint;

        public RecoveryVehicle(Vector3 recoveryPoint)
        {
            _recoveryPoint = recoveryPoint;
        }

        public void Execute(Transform target)
        {
            Debug.Log("Rcovery");
            target.position = _recoveryPoint;
        }
    }
}
