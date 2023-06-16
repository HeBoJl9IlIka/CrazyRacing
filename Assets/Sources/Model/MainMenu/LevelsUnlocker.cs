using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CrazyRacing.Model
{
    public class LevelsUnlocker
    {
        private IReadOnlyCollection<Level> _levels;
        private int _numberCurrentLevel;

        public LevelsUnlocker(IReadOnlyCollection<Level> levels)
        {
            _levels = levels;
            _numberCurrentLevel = ProgressGame.GetNumberCurrentLevel();
        }

        public void UnlockLevels()
        {
            if (_numberCurrentLevel > _levels.Count)
                _numberCurrentLevel = _levels.Count;

            for (int i = 0; i < _numberCurrentLevel; i++)
                _levels.ElementAt(i).Unlock();
        }
    }
}
