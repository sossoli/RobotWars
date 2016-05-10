using System.Collections.Generic;
using RobotWars.Arena;
using RobotWars.Positions;

namespace RobotWars.Robot
{
    public interface IRobot
    {
        IPosition Position { get; }
        void AddMoveCommand(string command);
        IList<string> GetMoveCommands();
        IArena GetArena();
        void Move();
    }
}