using System;

namespace CrazyRacing.Model
{
    public class CheckpointsCounter
    {
        private int _amountCheckpoints;

        public event Action<CheckpointView> Passed;
        public event Action LevelCompleted;

        public CheckpointsCounter(int amountCheckpoints)
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
