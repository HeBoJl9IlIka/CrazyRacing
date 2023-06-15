using CrazyRacing.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuPresenter : MonoBehaviour
{
    [SerializeField] private ButtonMainMenuPresenter _buttonMainMenu;

    private void OnEnable()
    {
        _buttonMainMenu.onClick.AddListener(OnClickMainMenu);
    }

    private void OnDisable()
    {
        _buttonMainMenu.onClick.RemoveListener(OnClickMainMenu);
    }

    private void OnClickMainMenu()
    {
        SceneManager.LoadScene(Config.NumberSceneMainMenu);
    }
}
