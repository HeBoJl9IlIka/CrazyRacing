using CrazyRacing.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGamePresenter : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private ButtonMainMenuPresenter _buttonMainMenu;
    [SerializeField] private ButtonContinuePresenter _buttonContinue;

    private PauseGame _model;

    private void OnEnable()
    {
        _model.Continued += OnPlaying;
        _model.Paused += OnPaused;
        _buttonContinue.onClick.AddListener(OnContinued);
        _buttonMainMenu.onClick.AddListener(OnExited);
    }

    private void OnDisable()
    {
        _model.Continued -= OnPlaying;
        _model.Paused -= OnPaused;
        _buttonContinue.onClick.RemoveListener(OnContinued);
        _buttonMainMenu.onClick.RemoveListener(OnExited);
    }

    public void Init(PauseGame pauseGame)
    {
        _model = pauseGame;
        enabled = true;
    }

    private void OnPlaying()
    {
        _menu.SetActive(false);
    }

    private void OnPaused()
    {
        _menu.SetActive(true);
    }

    private void OnContinued()
    {
        _model.Continue();
    }
    
    private void OnExited()
    {
        _model.Continue();
        SceneManager.LoadScene(Config.NumberSceneMainMenu);
    }
}
