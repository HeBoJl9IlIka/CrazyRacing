using CrazyRacing.Model;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRoot : MonoBehaviour
{
    [SerializeField] private LevelSetup[] _levelsSetups;

    private List<Levelmain> _levels = new List<Levelmain>();
    private LevelsUnlocker _levelsUnlocker;
    private SceneOpener _levelOpener = new SceneOpener();
    private ProgressGame _progressGame = new ProgressGame();

    private void Start()
    {
        Init();
        OnEnable();
        _levelsUnlocker.UnlockLevels();
    }

    private void OnEnable()
    {
        if (_levelsSetups != null)
        {
            foreach (var level in _levels)
                level.Opening += OnOpening;
        }
    }

    private void OnDisable()
    {
        foreach (var level in _levels)
            level.Opening -= OnOpening;
    }

    private void OnOpening(int number)
    {
        _levelOpener.OpenScene(number);
    }

    private void Init()
    {
        foreach (var levelSetup in _levelsSetups)
            _levels.Add(levelSetup.Model);

        _progressGame.Init();
        _levelsUnlocker = new LevelsUnlocker(_levels.ToArray(), _progressGame.GetNumberCurrentLevel());
        
    }
}
