using CrazyRacing.Model;

public class CreatorGelenvagen : CreatorVehicle
{
    public override Vehicle Create() => new Gelenvagen();
}

