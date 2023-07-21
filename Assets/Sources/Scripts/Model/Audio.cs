using Agava.WebUtility;
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
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
        }

        public static void Disable()
        {
            AudioListener.volume = Config.MinVolumeAudio;
            AudioListener.pause = true;
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        }

        public static void Switch()
        {
            if (IsEnabled)
                IsEnabled = false;
            else
                IsEnabled = true;
        }

        private static void OnInBackgroundChange(bool inBackground)
        {
            if (IsEnabled == false)
                return;

            AudioListener.pause = inBackground;
            AudioListener.volume = inBackground ? 0f : 1f;
            IsEnabled = inBackground ? false : true;
        }
    } 
}
