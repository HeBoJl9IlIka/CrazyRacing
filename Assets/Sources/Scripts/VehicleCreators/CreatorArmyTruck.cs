using CrazyRacing.Model;

public class CreatorArmyTruck : CreatorVehicle
{
    public override Vehicle Create() => new ArmyTruck();
}
