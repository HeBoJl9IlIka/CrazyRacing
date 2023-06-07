using UnityEngine;

public class CheckpointPresenter : LevelPresenter
{
    private LevelRoot _levelRoot;

    public override void Init(LevelRoot levelRoot)
    {
        _levelRoot = levelRoot;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out VehiclePresenter vehicle))
            _levelRoot.PassCheckpoint();
    }
}

