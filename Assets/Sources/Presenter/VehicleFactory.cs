using CrazyRacing.Model;
using System;
using System.Linq;
using UnityEngine;

public class VehicleFactory : MonoBehaviour
{
    [SerializeField] private VehiclePresenter[] _vehicleTemplates;

    private CreatorVehiclePresenter[] _creatorsPresenters;

    private void Awake()
    {
        CreatorVehiclePresenter[] creatorsPresenters =
        {
            new CreatorFerrari(),
            new CreatorNiva()
        };

        CustomizeCreator(creatorsPresenters);
        _creatorsPresenters = creatorsPresenters;
    }

    public void CreateVehicle(IVehicle vehicle)
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

    public virtual void Create(IVehicle vehicle)
    {
        VehiclePresenter presenter = MonoBehaviour.Instantiate(_template);
        presenter.Init(vehicle);
    }
}

public class CreatorFerrari : CreatorVehiclePresenter
{
    public override string VehicleName => Config.Ferrari;
}

public class CreatorNiva : CreatorVehiclePresenter
{
    public override string VehicleName => Config.Niva;
}