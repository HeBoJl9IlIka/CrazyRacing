using CrazyRacing.Model;

public class CreatorPickUp : CreatorVehicle
{
    public override Vehicle Create() => new PickUp();
}
