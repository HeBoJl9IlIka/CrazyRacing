using System;

namespace CrazyRacing.Model
{
    public class Level
    {
        public int Number { get; private set; }
        public int NormalizedNumber => Number + 1;

        public event Action Unlocked;

        public Level(int number)
        {
            Number = number;
        }

        public void Unlock()
        {
            Unlocked?.Invoke();
        }
    }
}
