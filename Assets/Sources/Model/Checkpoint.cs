using UnityEngine;
using UnityEngine.Events;

namespace MVVM
{
    public class Checkpoint
    {
        public event UnityAction<Transform> Passed;

        public void CanPassed(Transform transform)
        {
            if (transform.TryGetComponent(out Vehicle vehicle) == false)
                return;

            Passed?.Invoke(transform);
        }
    }
}
