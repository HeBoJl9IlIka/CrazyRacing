using CrazyRacing.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenerAllLevels : MonoBehaviour
{
    public void Open()
    {
        PlayerPrefs.SetInt(Config.NumberCurrentLevel, 25);
        SceneManager.LoadScene(0);
    }
}
