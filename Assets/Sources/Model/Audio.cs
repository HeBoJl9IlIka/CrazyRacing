using UnityEngine;

namespace CrazyRacing.Model 
{
    public static class Audio
    {
        public static bool IsEnabled { get; private set; }

        public static void Enable()
        {
            AudioListener.volume = Config.MaxVolumeAudio;
            AudioListener.pause = false;
        }

        public static void Disable()
        {
            AudioListener.volume = Config.MinVolumeAudio;
            AudioListener.pause = true;
        }

        public static void Customize()
        {
            if (IsEnabled)
                IsEnabled = false;
            else
                IsEnabled = true;
        }
    } 
}
