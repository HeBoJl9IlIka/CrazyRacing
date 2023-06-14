using System;

namespace CrazyRacing.Model
{
    public abstract class Vehicle
    {
        public virtual string Name { get; }

        public event Action Enabled;
        public event Action Disabled;

        public virtual void Enable()
        {
            Enabled?.Invoke();
        }

        public virtual void Disable()
        {
            Disabled?.Invoke();
        }
    }
}
