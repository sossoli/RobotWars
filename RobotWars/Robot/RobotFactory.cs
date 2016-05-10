using System;
using System.Collections.Generic;
using RobotWars.Positions;

namespace RobotWars.Robot
{
    public class RobotFactory : IRobotFactory
    {
        private Dictionary<string, Func<Point, IPosition>> _positionDictionary;

        public RobotFactory()
        {
            _positionDictionary = new Dictionary<string, Func<Point, IPosition>>()
            {
                {"N", CreateNorthPosition},
                {"S", CreateSouthPosition},
                {"W", CreateWestPosition},
                {"E", CreateEastPosition}
            };
        }

        private IPosition CreateEastPosition(Point position)
        {
            return new EastPosition(position);
        }

        private IPosition CreateWestPosition(Point position)
        {
            return new WestPosition(position);
        }

        private IPosition CreateSouthPosition(Point position)
        {
            return new SouthPosition(position);
        }

        private IPosition CreateNorthPosition(Point position)
        {
            return new NorthPosition(position);
        }

        public IRobot Create(string command, Arena.IArena arena)
        {
            var arguments = command.Split(' ');
            var x = int.Parse(arguments[0]);
            var y = int.Parse(arguments[1]);
            var orientation = arguments[2];
            return new Robot(_positionDictionary[orientation].Invoke(new Point(x, y)), arena);
        }
    }
}