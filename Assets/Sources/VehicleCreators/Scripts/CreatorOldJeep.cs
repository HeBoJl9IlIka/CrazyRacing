using CrazyRacing.Model;

public class CreatorOldJeep : CreatorVehicle
{
    public override Vehicle Create() => new OldJeep();
}
