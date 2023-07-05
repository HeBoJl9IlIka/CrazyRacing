using CrazyRacing.Model;

public class CreatorTruck : CreatorVehicle
{
    public override Vehicle Create() => new Truck();
}
