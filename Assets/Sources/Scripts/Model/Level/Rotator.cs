using System;
using UnityEngine;

namespace CrazyRacing.Model
{
    public static class Rotator
    {
        public enum Axis
        {
            X,
            Y,
            Z
        }

        public static Vector3 GetDirection(Axis[] axes)
        {
            Vector3 axisX = Vector3.zero;
            Vector3 axisY = Vector3.zero;
            Vector3 axisZ = Vector3.zero;

            if (Array.IndexOf(axes, Axis.X) != -1)
                axisX = new Vector3(Config.PropsStepRotate, 0, 0);

            if (Array.IndexOf(axes, Axis.Y) != -1)
                axisY = new Vector3(0, Config.PropsStepRotate, 0);

            if (Array.IndexOf(axes, Axis.Z) != -1)
                axisZ = new Vector3(0, 0, Config.PropsStepRotate);

            return axisX + axisY + axisZ;
        }
    }
}