namespace CrazyRacing.Model
{
    public class Ferrari : Vehicle
    {
        public override string Name => Config.Ferrari;

        public void Init()
        {

        }

        public void Recover(Point recoveryPoint)
        {
            //transform.position = recoveryPoint.transform.position;
            //transform.rotation = recoveryPoint.transform.rotation;
        }
    }
}
