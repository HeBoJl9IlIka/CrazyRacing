using System;
using UnityEngine;

namespace CrazyRacing.Model
{
    public class GamePause
    {
        private bool _isPaused;

        public event Action Continued;
        public event Action Paused;

        public void Switch()
        {
            if (_isPaused)
                Continue();
            else
                Pause();
        }

        public void Pause()
        {
            if (GamePauseController.IsPaused)
                return;

            Audio.Disable();
            Time.timeScale = 0;
            _isPaused = true;
            Paused?.Invoke();
            GamePauseController.Switch();
        }

        public void Continue()
        {
            if (Audio.IsEnabled)
                Audio.Enable();

            Time.timeScale = 1;
            _isPaused = false;
            Continued?.Invoke();
            GamePauseController.Switch();
        }
    }
}
