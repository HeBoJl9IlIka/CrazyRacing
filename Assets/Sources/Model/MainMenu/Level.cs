using System;

namespace CrazyRacing.Model
{
    public class Level
    {
        public int Number { get; private set; }

        public event Action<int> Opening;
        public event Action Unlocked;

        public Level(int number)
        {
            Number = number;
        }

        public void Open()
        {
            Opening?.Invoke(Number);
        }

        public void Unlock()
        {
            Unlocked?.Invoke();
        }
    }
}
