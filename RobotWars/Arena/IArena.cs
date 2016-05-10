using RobotWars.Positions;

namespace RobotWars.Arena
{
    public interface IArena
    {
        Size GetSize();
        bool IsValid(Point point);
    }
}