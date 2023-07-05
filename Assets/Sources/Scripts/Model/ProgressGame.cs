using CrazyRacing.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ProgressGame
{
    public static void Init()
    {
        if (PlayerPrefs.GetInt(Config.NumberCurrentLevel) == 0)
            PlayerPrefs.SetInt(Config.NumberCurrentLevel, Config.NumberFirstLevel);
    }

    public static int GetNumberCurrentLevel()
    {
        return PlayerPrefs.GetInt(Config.NumberCurrentLevel);
    }

    public static void SaveProgress()
    {
        int numberLevel = SceneManager.GetActiveScene().buildIndex;
        int numberLastLevel = PlayerPrefs.GetInt(Config.NumberCurrentLevel);

        if (numberLevel < numberLastLevel)
            return;

        if (numberLevel == PlayerPrefs.GetInt(Config.NumberCurrentLevel))
            ++numberLevel;

        PlayerPrefs.SetInt(Config.NumberCurrentLevel, numberLevel);
    }
}
