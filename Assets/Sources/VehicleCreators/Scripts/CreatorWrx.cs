using CrazyRacing.Model;

public class CreatorWrx : CreatorVehicle
{
    public override Vehicle Create() => new Wrx();
}
