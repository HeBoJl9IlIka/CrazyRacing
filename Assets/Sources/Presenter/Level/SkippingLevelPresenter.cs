using CrazyRacing.Model;
using UnityEngine;

public class SkippingLevelPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private ButtonSkipLevelPresenter _buttonSkipLevel;
    [SerializeField] private ButtonContinuePresenter _buttonContinue;

    private GamePause _model;

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
        _buttonContinue.onClick.AddListener(OnContinued);
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
        _model.Continue();
        Debug.Log("SKIPPED!");
    }

    private void OnContinued()
    {
        _model.Continue();
        _menu.SetActive(false);
    }
}
