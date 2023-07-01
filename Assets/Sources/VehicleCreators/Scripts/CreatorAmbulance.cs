using CrazyRacing.Model;

public class CreatorAmbulance : CreatorVehicle
{
    public override Vehicle Create() => new Ambulance();
}
