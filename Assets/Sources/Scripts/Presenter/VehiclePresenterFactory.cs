using CrazyRacing.Model;
using System;
using System.Linq;
using UnityEngine;

public class VehiclePresenterFactory : MonoBehaviour
{
    [SerializeField] private VehiclePresenter[] _vehicleTemplates;

    private CreatorVehiclePresenter[] _creatorsPresenters;

    private void Awake()
    {
        CreatorVehiclePresenter[] creatorsPresenters =
        {
            new CreatorFerrariPresenter(),
            new CreatorNivaPresenter(),
            new CreatorBmwPresenter(),
            new CreatorFordPresenter(),
            new CreatorGolfPresenter(),
            new CreatorOldJeepPresenter(),
            new CreatorPickUpPresenter(),
            new CreatorOldMercedesPresenter(),
            new CreatorWrxPresenter(),
            new CreatorBmwMPresenter(),
            new CreatorAudiPresenter(),
            new CreatorLamborghiniPresenter(),
            new CreatorChevroletSportPresenter(),
            new CreatorFocusSportPresenter(),
            new CreatorAmbulancePresenter(),
            new CreatorGelenvagenPresenter(),
            new CreatorArmyTruckPresenter(),
            new CreatorTruckPresenter(),
            new CreatorMonsterTruckPresenter()
        };

        CustomizeCreator(creatorsPresenters);
        _creatorsPresenters = creatorsPresenters;
    }

    public void Create(Vehicle vehicle)
    {
        CreatorVehiclePresenter creator = _creatorsPresenters.FirstOrDefault(creator => creator.VehicleName == vehicle.Name);
        creator.Create(vehicle);
    }

    private void CustomizeCreator(CreatorVehiclePresenter[] creatorsPresenters)
    {
        foreach (var creator in creatorsPresenters)
        {
            VehiclePresenter presenter = _vehicleTemplates.FirstOrDefault(presenter => presenter.VehicleName == creator.VehicleName);

            if (presenter == null)
                throw new ArgumentNullException(nameof(presenter));

            creator.Init(presenter);
        }
    }
}

public abstract class CreatorVehiclePresenter
{
    private VehiclePresenter _template;

    public virtual string VehicleName { get; }

    public void Init(VehiclePresenter template)
    {
        _template = template;
    }

    public void Create(Vehicle vehicle)
    {
        VehiclePresenter presenter = UnityEngine.Object.Instantiate(_template);
        presenter.Init(vehicle);
    }
}

public class CreatorFerrariPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.Ferrari;
}

public class CreatorNivaPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.Niva;
}

public class CreatorBmwPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.Bmw;
}

public class CreatorFordPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.Ford;
}

public class CreatorGolfPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.Golf;
}

public class CreatorOldJeepPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.OldJeep;
}

public class CreatorPickUpPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.PickUp;
}

public class CreatorOldMercedesPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.OldMercedes;
}

public class CreatorWrxPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.Wrx;
}

public class CreatorBmwMPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.BmwM;
}

public class CreatorAudiPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.Audi;
}

public class CreatorLamborghiniPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.Lamborghini;
}

public class CreatorChevroletSportPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.ChevroletSport;
}

public class CreatorFocusSportPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.FocusSport;
}

public class CreatorAmbulancePresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.Ambulance;
}

public class CreatorGelenvagenPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.Gelenvagen;
}

public class CreatorArmyTruckPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.ArmyTruck;
}

public class CreatorTruckPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.Truck;
}

public class CreatorMonsterTruckPresenter : CreatorVehiclePresenter
{
    public override string VehicleName => Config.MonsterTruck;
}