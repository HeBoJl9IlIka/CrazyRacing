using CrazyRacing.Model;

public class CreatorBmw : CreatorVehicle
{
    public override Vehicle Create() => new Bmw();
}
