using CrazyRacing.Model;
using System;
using UnityEngine;

public class SkippingLevelPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private ButtonSkipLevelPresenter _buttonSkipLevel;
    [SerializeField] private ButtonContinuePresenter _buttonContinue;

    private GamePause _model;

    public event Action Skipped;

    private void OnEnable()
    {
        _model.Paused += OnPaused;
        _buttonSkipLevel.onClick.AddListener(OnSkippedLevel);
        _buttonContinue.onClick.AddListener(OnContinued);
    }

    private void OnDisable()
    {
        _model.Paused -= OnPaused;
        _buttonSkipLevel.onClick.RemoveListener(OnSkippedLevel);
        _buttonContinue.onClick.RemoveListener(OnContinued);
    }

    public void Init(GamePause pauseGame)
    {
        _model = pauseGame;
        enabled = true;
    }

    private void OnPaused()
    {
        _menu.SetActive(true);
    }

    private void OnSkippedLevel()
    {
        Invoke(nameof(ShowVideo), Config.DelayShowVideo);
        _model.Slowmo();
    }

    private void OnContinued()
    {
        _model.Continue();
        _menu.SetActive(false);
    }

    private void ShowVideo()
    {
        _model.Continue();
        _menu.SetActive(false);
        Skipped?.Invoke();
    }
}
