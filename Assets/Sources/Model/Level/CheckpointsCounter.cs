using System;

namespace CrazyRacing.Model
{
    public class CheckpointsCounter
    {
        private int _amountCheckpoints;
        private int _numberCurrentCheckpoint;

        public int AmountCheckpoints => _amountCheckpoints;

        public event Action<CheckpointView, int> Passed;
        public event Action LevelCompleted;

        public CheckpointsCounter(int amountCheckpoints)
        {
            _amountCheckpoints = amountCheckpoints;
        }

        public void CountCheckpoint(CheckpointView checkpoint)
        {
            ++_numberCurrentCheckpoint;
            Passed?.Invoke(checkpoint, _numberCurrentCheckpoint);

            if (_numberCurrentCheckpoint == _amountCheckpoints)
                LevelCompleted?.Invoke();
        }
    }
}
