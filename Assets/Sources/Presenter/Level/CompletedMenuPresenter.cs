using CrazyRacing.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedMenuPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private ButtonMainMenuPresenter _buttonMainMenu;
    [SerializeField] private ButtonNextLevelPresenter _buttonNextLevel;

    private PauseGame _model;

    public void Init(PauseGame pauseGame)
    {
        _model = pauseGame;
        enabled = true;
    }

    private void OnEnable()
    {
        _model.Paused += OnPaused;
        _buttonMainMenu.onClick.AddListener(OnClickMenu);
        _buttonNextLevel.onClick.AddListener(OnClickNextLevel);
    }

    private void OnDisable()
    {
        _model.Paused -= OnPaused;
        _buttonMainMenu.onClick.RemoveListener(OnClickMenu);
        _buttonNextLevel.onClick.RemoveListener(OnClickNextLevel);
    }

    private void OnPaused()
    {
        _menu.SetActive(true);
    }

    private void OnClickNextLevel()
    {
        _model.Continue();
        Scene scene = SceneManager.GetActiveScene();
        int number = scene.buildIndex;
        SceneManager.LoadScene(++number);
    }

    private void OnClickMenu()
    {
        _model.Continue();
        SceneManager.LoadScene(Config.NumberSceneMainMenu);
    }
}
