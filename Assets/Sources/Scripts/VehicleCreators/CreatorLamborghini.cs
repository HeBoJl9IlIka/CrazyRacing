using CrazyRacing.Model;

public class CreatorLamborghini : CreatorVehicle
{
    public override Vehicle Create() => new Lamborghini();
}
