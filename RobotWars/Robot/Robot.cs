using System.Collections.Generic;
using System.Linq;
using RobotWars.Arena;
using RobotWars.Positions;

namespace RobotWars.Robot
{
    public class Robot : IRobot
    {
        private IPosition _position;
        private List<string> _moveCommands;
        private IArena _arena;

        public IPosition Position { get { return _position; } }

        public Robot(IPosition position, IArena arena)
        {
            _position = position;
            _arena = arena;
            _moveCommands = new List<string>();
        }

        
        public void AddMoveCommand(string command)
        {
            _moveCommands.Add(command);
        }

        public IList<string> GetMoveCommands()
        {
            return _moveCommands;
        }

        public IArena GetArena()
        {
            return _arena;
        }

        public void Move()
        {
            _moveCommands.ForEach(commands => commands.ToCharArray().ToList().ForEach(c =>
            {
                IPosition newPosition = _position.Execute(c);
                if (_arena.IsValid(newPosition.Point))
                    _position = newPosition;
            }));
        }
    }
}