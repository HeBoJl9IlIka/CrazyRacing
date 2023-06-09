using System;

namespace CrazyRacing.Model
{
    public class CheckpointsСounter
    {
        private int _amountCheckpoints;

        public event Action<CheckpointView> Passed;
        public event Action LevelCompleted;

        public CheckpointsСounter(int amountCheckpoints)
        {
            _amountCheckpoints = amountCheckpoints;
        }

        public void CountCheckpoint(CheckpointView checkpoint)
        {
            --_amountCheckpoints;
            Passed?.Invoke(checkpoint);

            if (_amountCheckpoints == 0)
                LevelCompleted?.Invoke();
        }
    }
}
