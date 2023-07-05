using CrazyRacing.Model;
using UnityEngine;

public class CheckpointPresenterFactory : MonoBehaviour
{
    [SerializeField] private CheckpointPresenter[] _checkpointsPresenters;

    public int AmountCheckpoints => _checkpointsPresenters.Length;

    public void InitPresenter(Checkpoint checkpoint, int index)
    {
        _checkpointsPresenters[index].Init(checkpoint);
    }
}
