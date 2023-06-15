using System;
using UnityEngine;

namespace CrazyRacing.Model
{
    public abstract class Vehicle
    {
        public virtual string Name { get; }

        public event Action Enabled;
        public event Action Disabled;
        public event Action Stopped;
        public event Action<Vector3, Vector3> Recovered;
        public event Action<Vector3> RotatingVertical;
        public event Action<Vector3> RotatingHorizontal;

        public virtual void Enable()
        {
            Enabled?.Invoke();
        }

        public virtual void Disable()
        {
            Disabled?.Invoke();
        }

        public void Recover(Vector3 position, Vector3 rotation)
        {
            Recovered?.Invoke(position, rotation);
        }

        public void RotateVertical(float direction)
        {
            Vector3 vector = new Vector3(0, 0, direction) * Time.deltaTime * Config.RotationForce;
            RotatingVertical?.Invoke(vector);
        }

        public void RotateHorizontal(float direction)
        {
            Vector3 vector = new Vector3(direction, 0, 0) * Time.deltaTime * Config.RotationForce;
            RotatingHorizontal?.Invoke(vector);
        }

        public void Stop()
        {
            Stopped?.Invoke();
        }
    }
}
