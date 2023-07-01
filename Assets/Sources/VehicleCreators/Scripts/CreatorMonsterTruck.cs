using CrazyRacing.Model;

public class CreatorMonsterTruck : CreatorVehicle
{
    public override Vehicle Create() => new MonsterTruck();
}
