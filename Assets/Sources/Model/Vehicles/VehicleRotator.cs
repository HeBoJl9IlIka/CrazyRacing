using System;
using UnityEngine;

namespace CrazyRacing.Model
{
    public class VehicleRotator
    {
        private float _force = 5;

        public event Action<Vector3> RotatingVertical;
        public event Action<Vector3> RotatingHorizontal;

        public void RotateVertical(float direction)
        {
            Vector3 vector = new Vector3(0, 0, direction) * Time.deltaTime * _force;
            RotatingVertical?.Invoke(vector);
        }

        public void RotateHorizontal(float direction)
        {
            Vector3 vector = new Vector3(direction, 0, 0) * Time.deltaTime * _force;
            RotatingHorizontal?.Invoke(vector);
        }
    }
}