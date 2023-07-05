namespace CrazyRacing.Model
{
    public static class GamePauseController
    {
        public static bool IsPaused { get; private set; }

        public static void Switch()
        {
            if (IsPaused)
                IsPaused = false;
            else
                IsPaused = true;
        }
    }
}
