using CrazyRacing.Model;

public class CreatorNiva : CreatorVehicle
{
    public override Vehicle Create() => new Niva();
}