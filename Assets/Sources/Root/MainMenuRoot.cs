using CrazyRacing.Model;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuRoot : MonoBehaviour
{
    [SerializeField] private LevelsPresentersInitializer _levelsPresentersInitializer;
    [SerializeField] private ButtonContinuePresenter _buttonContinue;

    private Level[] _levels;

    private LevelsUnlocker _levelsUnlocker;

    public IReadOnlyCollection<Level> Levels => _levels;

    private void Awake()
    {
        CreateLevels();
        ProgressGame.Init();
        _levelsUnlocker = new LevelsUnlocker(Levels);
        _levelsUnlocker.UnlockLevels();
    }

    private void OnEnable()
    {
        _buttonContinue.onClick.AddListener(OnContinue);
    }

    private void OnDisable()
    {
        _buttonContinue.onClick.RemoveListener(OnContinue);
    }

    private void OnContinue()
    {
        SceneManager.LoadScene(ProgressGame.GetNumberCurrentLevel());
    }

    private void CreateLevels()
    {
        _levels = new Level[_levelsPresentersInitializer.AmountPresenters];

        for (int i = 0; i < _levels.Length; i++)
            _levels[i] = new Level(i);

        foreach (var level in _levels)
            _levelsPresentersInitializer.InitPresenter(level);
    }
}
