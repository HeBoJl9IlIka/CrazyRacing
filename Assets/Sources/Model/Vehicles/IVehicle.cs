using NWH;
using UnityEngine;

public enum NameVehicles
{
    BMW,
    Mercedes,
    Lada,
    Bus,
    Truck,
    Subaru
}

public interface IVehicle
{
    public NameVehicles Name { get; }
}
