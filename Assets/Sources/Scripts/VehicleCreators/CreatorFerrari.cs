using CrazyRacing.Model;

public class CreatorFerrari : CreatorVehicle
{
    public override Vehicle Create() => new Ferrari();
}
