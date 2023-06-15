using System;

namespace CrazyRacing.Model
{
    public class Checkpoint
    {
        public event Action Showed;
        public event Action Hided;
        public event Action Disabled;
        public event Action<Checkpoint> Passed;

        public void Enable()
        {
            Showed?.Invoke();
        }

        public void Disable()
        {
            Disabled?.Invoke();
        }

        public void Pass()
        {
            Passed?.Invoke(this);
        }

        public void Hide()
        {
            Hided?.Invoke();
        }
    }
}
