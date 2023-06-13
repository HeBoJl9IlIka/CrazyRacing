using System;
using UnityEngine;

public class CheckpointsCounterView : MonoBehaviour
{
    private const float Delay = 1f;

    private CheckpointView[] _checkpoints;
    private CheckpointView _current;

    public int AmountCheckpoints => _checkpoints.Length;

    public event Action<CheckpointView> Passing;

    private void Awake()
    {
        _checkpoints = GetComponentsInChildren<CheckpointView>();
    }

    private void Start()
    {
        SetupCheckpoints();
    }

    private void OnEnable()
    {
        foreach (var checkpoint in _checkpoints)
            checkpoint.Passed += OnPassed;
    }

    private void OnDisable()
    {
        foreach (var checkpoint in _checkpoints)
            checkpoint.Passed -= OnPassed;
    }

    public void ChangeCheckpoint(CheckpointView checkpoint)
    {
        if (checkpoint == _checkpoints[^1])
            return;

        for (int i = 0; i < _checkpoints.Length; i++)
        {
            if (_checkpoints[i] == checkpoint)
                _current = _checkpoints[++i];
        }

        _current.gameObject.SetActive(true);
        checkpoint.gameObject.SetActive(false);
        Invoke(nameof(EnableCurrentCollider), Delay);
    }

    private void OnPassed(CheckpointView checkpoint)
    {
        Passing?.Invoke(checkpoint);
    }

    private void EnableCurrentCollider()
    {
        if (_current.TryGetComponent(out BoxCollider collider))
            collider.enabled = true;
    }

    private void SetupCheckpoints()
    {
        foreach (var checkpoint in _checkpoints)
        {
            checkpoint.TryGetComponent(out BoxCollider collider);

            if (checkpoint != _checkpoints[0])
            {
                collider.enabled = false;
                checkpoint.gameObject.SetActive(false);
            }
        }
    }
}
