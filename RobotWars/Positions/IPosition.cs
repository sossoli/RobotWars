namespace RobotWars.Positions
{
    public interface IPosition
    {
        Point Point { get; }
        IPosition Execute(char command);
    }
}