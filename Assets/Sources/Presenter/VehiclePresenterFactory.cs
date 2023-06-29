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
            new CreatorWrxPresenter()
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

    public virtual void Init(VehiclePresenter template)
    {
        _template = template;
    }

    public virtual void Create(Vehicle vehicle)
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