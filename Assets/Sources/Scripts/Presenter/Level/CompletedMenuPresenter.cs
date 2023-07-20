using CrazyRacing.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedMenuPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private ButtonMainMenuPresenter _buttonMainMenu;
    [SerializeField] private ButtonNextLevelPresenter _buttonNextLevel;

    private GamePause _model;

    public void Init(GamePause pauseGame)
    {
        _model = pauseGame;
        enabled = true;
    }

    private void OnEnable()
    {
        _model.Paused += OnPaused;
        _model.Continued += OnContinued;
        _buttonMainMenu.onClick.AddListener(OnClickMenu);
        _buttonNextLevel.onClick.AddListener(OnClickNextLevel);
    }

    private void OnDisable()
    {
        _model.Paused -= OnPaused;
        _model.Continued -= OnContinued;
        _buttonMainMenu.onClick.RemoveListener(OnClickMenu);
        _buttonNextLevel.onClick.RemoveListener(OnClickNextLevel);
    }

    private void OnPaused()
    {
        _menu.SetActive(true);
    }

    private void OnContinued()
    {
        _menu.SetActive(false);
    }

    private void OnClickNextLevel()
    {
        _model.Continue();
        int number = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++number);
    }

    private void OnClickMenu()
    {
        _model.Continue();
        SceneManager.LoadScene(Config.NumberSceneMainMenu);
    }
}
