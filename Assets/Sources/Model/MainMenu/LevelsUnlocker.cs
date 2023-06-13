namespace CrazyRacing.Model
{
    public class LevelsUnlocker
    {
        private Level[] _levels;
        private int _numberCurrentLevel;

        public LevelsUnlocker(Level[] levels, int numberCurrentLevel)
        {
            _levels = levels;
            _numberCurrentLevel = numberCurrentLevel;
        }

        public void UnlockLevels()
        {
            for (int i = 0; i < _numberCurrentLevel; i++)
                _levels[i].Unlock();
        }
    }
}
