using CrazyRacing.Model;
using System;
using UnityEngine;

public class LevelsPresentersInitializer : MonoBehaviour
{
    [SerializeField] private LevelPresenter[] _levelsPresenters;

    public int AmountPresenters => _levelsPresenters.Length;

    public void InitPresenter(Level level)
    {
        if (_levelsPresenters[level.Number] == null)
            throw new ArgumentOutOfRangeException(nameof(level.Number));

        LevelPresenter levelPresenter = _levelsPresenters[level.Number];
        levelPresenter.Init(level);
    }
}
