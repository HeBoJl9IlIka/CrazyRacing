using CrazyRacing.Model;

public class CreatorBmwM : CreatorVehicle
{
    public override Vehicle Create() => new BmwM();
}
