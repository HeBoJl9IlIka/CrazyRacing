namespace CrazyRacing.Model
{
    public static class Config
    {
        public const int NumberSceneMainMenu = 0;
        public const int NumberFirstLevel = 1;
        public const int MaxAmountRecovery = 5;
        public const int LayerRoad = 10;

#if !UNITY_WEBGL || UNITY_EDITOR
        public const float VehicleRotationForce = 10f;
#else
        public const float VehicleRotationForce = 2f;
#endif
        public const float DelayEnablingCheckpointCollider = 1f;
        public const float ProgressBarFillingDuration = 1f;
        public const float MaxVolumeAudio = 1f;
        public const float MinVolumeAudio = 0f;
        public const float BoostForce = 1000f;
        public const float FlashingDuration = 0.5f;
        public const float StopForce = 10f;
        public const float MinSpeedForBoost = 3f;
        public const float PropsStepRotate = 1f;
        public const float DefaultAngularVelocity = 8f;
        public const float VehicleMaxAngularVelocity = 2f;
        public const float DelayShowVideo = 0.1f;
        public const float BarrierMaxAngularVelocity = 1.5f;
        public const float BarrierMinAngularVelocity = -0.5f;

        public const string NumberCurrentLevel = "NumberCurrentLevel";
        public const string TagRoad = "Road";

        public const string Ferrari = "Ferrari";
        public const string Niva = "Niva";
        public const string Bmw = "Bmw";
        public const string BmwM = "BmwM";
        public const string Ford = "Ford";
        public const string Golf = "Golf";
        public const string OldJeep = "OldJeep";
        public const string PickUp = "PickUp";
        public const string OldMercedes = "OldMercedes";
        public const string Wrx = "Wrx";
        public const string Audi = "Audi";
        public const string Lamborghini = "Lamborghini";
        public const string ChevroletSport = "ChevroletSport";
        public const string FocusSport = "FocusSport";
        public const string Ambulance = "Ambulance";
        public const string Gelenvagen = "Gelenvagen";
        public const string ArmyTruck = "ArmyTruck";
        public const string Truck = "Truck";
        public const string MonsterTruck = "MonsterTruck";

        public const string EnglishCode = "en";
        public const string RussianCode = "ru";
        public const string TurkishCode = "tr";
        public const string EnglishLanguage = "English";
        public const string RussianLanguage = "Russian";
        public const string TurkishLanguage = "Turkish";
    }
}
