using System;

namespace CrazyRacing.Model
{
    public class LevelOpener
    {
        public event Action<int> Opening;

        internal void OpenLevel(int number)
        {
            Opening?.Invoke(number);
        }
    }
}
