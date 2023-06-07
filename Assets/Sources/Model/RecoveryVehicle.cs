using UnityEngine;

namespace CrazyRacing.Model
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
            target.position = _recoveryPoint;
            target.eulerAngles = _recoveryPoint;
        }
    }
}
