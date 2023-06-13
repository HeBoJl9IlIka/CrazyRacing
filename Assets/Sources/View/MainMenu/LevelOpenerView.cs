using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOpenerView : MonoBehaviour
{
    public void OpenLevel(int number)
    {
        SceneManager.LoadScene(number);
    }
}
