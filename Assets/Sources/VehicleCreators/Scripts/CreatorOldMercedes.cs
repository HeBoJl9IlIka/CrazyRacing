using CrazyRacing.Model;

public class CreatorOldMercedes : CreatorVehicle
{
    public override Vehicle Create() => new OldMercedes();
}
