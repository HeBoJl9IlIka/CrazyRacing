using UnityEngine;

public abstract class LevelPresenter : MonoBehaviour
{
    public virtual void Init(LevelRoot levelRoot) { }
    public virtual VehiclePresenter[] CreateVehicles() => default;
}
