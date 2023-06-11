using System;

namespace CrazyRacing.Model
{
    public class VehicleRotator
    {
        public event Action<float> RotatingHorizontal;
        public event Action<float> RotatingVertical;

        public void RotateHorizontal(float direction)
        {
            RotatingHorizontal?.Invoke(direction);
        }

        public void RotateVertical(float direction)
        {
            RotatingVertical?.Invoke(direction);
        }
    }
}