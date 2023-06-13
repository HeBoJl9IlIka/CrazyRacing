using UnityEngine.SceneManagement;

namespace CrazyRacing.Model
{
    public class SceneOpener
    {
        public void OpenScene(int number)
        {
            SceneManager.LoadScene(number);
        }
    }
}
