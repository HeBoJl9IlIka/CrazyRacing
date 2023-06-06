using NWH.Common.Input;
using UnityEngine;

namespace MVVM
{
    public class RecoveryVehicleViewModel : ViewModel
    {
        [SerializeField] private VehiclePoolViewModel _vehiclePoolViewModel;

        [Model] private RecoveryVehicle _recoveryVehicle;
        //private SceneInputActions sceneInputActions;

        public Transform Traget => _vehiclePoolViewModel.CurrentVehicle.transform;

        private void Awake()
        {
            _recoveryVehicle = new RecoveryVehicle(transform.position);
            //sceneInputActions = new SceneInputActions();
        }

        //private void OnEnable()
        //{
        //    sceneInputActions.Enable();
        //}

        //private void OnDisable()
        //{
        //    sceneInputActions.Disable();
        //}

        [Command]
        public void RecoveryVehicle() => _recoveryVehicle.Execute(Traget);
    }
}