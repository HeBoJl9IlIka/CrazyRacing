using UnityEngine;

namespace MVVM
{
    public class CheckpointViewModel : ViewModel
    {
        [Model] private Checkpoint _checkpoint = new Checkpoint();

        public Checkpoint Checkpoint => _checkpoint;

        [Command]
        private void OnTriggerEnter(Collider other) => _checkpoint.CanPassed(other.transform);
    }
}
