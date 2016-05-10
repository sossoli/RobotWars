using RobotWars.Arena;

namespace RobotWars.Robot
{
    public interface IRobotFactory
    {
        IRobot Create(string command, IArena arena);
    }
}