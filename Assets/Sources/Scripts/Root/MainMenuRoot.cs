using CrazyRacing.Model;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuRoot : MonoBehaviour
{
    [SerializeField] private LevelsPresentersInitializer _levelsPresentersInitializer;
    [SerializeField] private ButtonContinuePresenter _buttonContinue;
    [SerializeField] private GameObject _block;
    [SerializeField] private Sdk[] _sdks;

    private Level[] _levels;
    private LevelsUnlocker _levelsUnlocker;

    public IReadOnlyCollection<Level> Levels => _levels;

    private void Awake()
    {
        _block.gameObject.SetActive(true);
        CreateLevels();
        ProgressGame.Init();
        _levelsUnlocker = new LevelsUnlocker(Levels);
        _levelsUnlocker.UnlockLevels();
    }

    private void Start()
    {
        if (SdkFactory.Sdk == null)
            SdkFactory.Init(_sdks);
    }

    private void OnEnable()
    {
        _buttonContinue.onClick.AddListener(OnContinue);
        SdkFactory.Initialized += OnInitialized;
    }

    private void OnDisable()
    {
        _buttonContinue.onClick.RemoveListener(OnContinue);
        SdkFactory.Initialized -= OnInitialized;
        SdkFactory.Unsubscribe();
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

    private void OnInitialized()
    {
        _block.SetActive(false);
    }
}
