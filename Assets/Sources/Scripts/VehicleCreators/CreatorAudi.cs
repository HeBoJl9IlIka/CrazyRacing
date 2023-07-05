using CrazyRacing.Model;

public class CreatorAudi : CreatorVehicle
{
    public override Vehicle Create() => new Audi();
}
