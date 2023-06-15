using System;
using UnityEngine;

namespace CrazyRacing.Model
{
    public class PauseGame
    {
        private bool _isPaused;

        public event Action Continued;
        public event Action Paused;

        public void Execute()
        {
            if (_isPaused)
                Continue();
            else
                Pause();
        }

        public void Pause()
        {
            Audio.Disable();
            Time.timeScale = 0;
            _isPaused = true;
            Paused?.Invoke();
        }

        public void Continue()
        {
            if (Audio.IsEnabled)
                Audio.Enable();

            Time.timeScale = 1;
            _isPaused = false;
            Continued?.Invoke();
        }
    }
}
