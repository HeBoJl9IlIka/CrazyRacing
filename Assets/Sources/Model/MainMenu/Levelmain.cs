using System;

namespace CrazyRacing.Model
{
    public class Levelmain
    {
        public int Number { get; private set; }

        public event Action<int> Opening;
        public event Action Unlocked;

        public Levelmain(int number)
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
