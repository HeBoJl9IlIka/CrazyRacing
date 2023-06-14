using System;

namespace CrazyRacing.Model
{
    public class CheckpointsCounter
    {
        private int _amountCheckpoints;
        private int _numberCurrentCheckpoint;

        public int AmountCheckpoints => _amountCheckpoints;

        public event Action<CheckpointPresenter, int> Passed;
        public event Action LevelCompleted;

        public CheckpointsCounter(int amountCheckpoints)
        {
            _amountCheckpoints = amountCheckpoints;
        }

        public void CountCheckpoint(CheckpointPresenter checkpoint)
        {
            ++_numberCurrentCheckpoint;
            Passed?.Invoke(checkpoint, _numberCurrentCheckpoint);

            if (_numberCurrentCheckpoint == _amountCheckpoints)
                LevelCompleted?.Invoke();
        }
    }
}
