using System;

namespace CrazyRacing.Model
{
    public class CheckpointsCounter
    {
        private Checkpoint[] _checkpoints;
        private int _amountCheckpoints;
        private int _numberCurrentCheckpoint = 0;

        public event Action LevelCompleted;
        public event Action<Checkpoint, int> CreatedCheckpoint;

        public CheckpointsCounter(int amountCheckpoints)
        {
            _amountCheckpoints = amountCheckpoints;
            _checkpoints = new Checkpoint[amountCheckpoints];
        }

        public void Init()
        {
            CustomizeCheckpoints();
            EnableFirstCheckpoint();
        }

        public void CountCheckpoint()
        {
            ++_numberCurrentCheckpoint;

            if (_numberCurrentCheckpoint == _amountCheckpoints)
                LevelCompleted?.Invoke();
        }

        public void ChangeCheckpoint(Checkpoint checkpoint)
        {
            if (checkpoint == _checkpoints[^1])
            {
                _checkpoints[^1].Disable();
                return;
            }

            int index = _numberCurrentCheckpoint;
            _checkpoints[--index].Disable();
            _checkpoints[_numberCurrentCheckpoint].Enable();
        }

        private void EnableFirstCheckpoint()
        {
            _checkpoints[_numberCurrentCheckpoint].Enable();
        }

        private void CustomizeCheckpoints()
        {
            for (int i = 0; i < _checkpoints.Length; i++)
            {
                _checkpoints[i] = new Checkpoint();
                CreatedCheckpoint?.Invoke(_checkpoints[i], i);
                _checkpoints[i].Hide();
            }
        }
    }
}
