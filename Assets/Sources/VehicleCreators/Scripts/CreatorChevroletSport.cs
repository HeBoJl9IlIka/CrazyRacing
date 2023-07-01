using CrazyRacing.Model;

public class CreatorChevroletSport : CreatorVehicle
{
    public override Vehicle Create() => new ChevroletSport();
}
