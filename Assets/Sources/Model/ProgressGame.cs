using UnityEngine;

namespace CrazyRacing.Model
{
    public class ProgressGame
    {
        private const int FirstLevel = 1;
        private const string NumberCurrentLevel = "NumberCurrentLevel";

        public void Init()
        {
            if (PlayerPrefs.GetInt(NumberCurrentLevel) == 0)
                PlayerPrefs.SetInt(NumberCurrentLevel, FirstLevel);
        }

        public int GetNumberCurrentLevel()
        {
            return PlayerPrefs.GetInt(NumberCurrentLevel);
        }

        public void SaveProgress(int numberLevel)
        {
            PlayerPrefs.SetInt(NumberCurrentLevel, numberLevel);
        }
    }
}
