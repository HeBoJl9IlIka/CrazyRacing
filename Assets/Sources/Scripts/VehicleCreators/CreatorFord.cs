using CrazyRacing.Model;

public class CreatorFord : CreatorVehicle
{
    public override Vehicle Create() => new Ford();
}
