using CrazyRacing.Model;

public class CreatorFocusSport : CreatorVehicle
{
    public override Vehicle Create() => new FocusSport();
}
