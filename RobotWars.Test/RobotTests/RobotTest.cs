using System;
using NUnit.Framework;
using RobotWars.Positions;
using RobotWars.Robot;

namespace RobotWars.Test.RobotTests
{
    [TestFixture]
    public class RobotTest
    {
        private IRobot _robot;
        private Arena.IArena _arena;
        private IPosition _position;

        [SetUp]
        public void Setup()
        {
            _arena = new Arena.Arena(new Size(5, 5));
            
        }

        [TestCase("LLRM", 1, 2, typeof(WestPosition))]
        [TestCase("LLLMM", 4, 2, typeof(EastPosition))]
        [TestCase("MMM", 2, 5, typeof(NorthPosition))]
        [TestCase("LLMMM", 2, 0, typeof(SouthPosition))]
        [TestCase("RMMLMLM", 3, 3, typeof(WestPosition))]
        public void Move_NorhtPosition_should_update_the_position(string commands, int x, int y, Type positionType)
        {
            _position = new NorthPosition(new Point(2, 2));
            _robot = new Robot.Robot(_position, _arena);
            _robot.AddMoveCommand(commands);

            _robot.Move();

            Assert.AreEqual(positionType, _robot.Position.GetType());
            Assert.AreEqual(x, _robot.Position.Point.X);
            Assert.AreEqual(y, _robot.Position.Point.Y);
        }

        [TestCase("LLRM", 2, 1, typeof(SouthPosition))]
        [TestCase("LLLMM", 2, 4, typeof(NorthPosition))]
        [TestCase("MMM", 0, 2, typeof(WestPosition))]
        [TestCase("LLMMM", 5, 2, typeof(EastPosition))]
        [TestCase("RMMLMLM", 1, 3, typeof(SouthPosition))]
        public void Move_WestPosition_should_update_the_position(string commands, int x, int y, Type positionType)
        {
            _position = new WestPosition(new Point(2, 2));
            _robot = new Robot.Robot(_position, _arena);
            _robot.AddMoveCommand(commands);

            _robot.Move();

            Assert.AreEqual(positionType, _robot.Position.GetType());
            Assert.AreEqual(x, _robot.Position.Point.X);
            Assert.AreEqual(y, _robot.Position.Point.Y);
        }

        [TestCase("LLRM", 3, 2, typeof(EastPosition))]
        [TestCase("LLLMM", 0, 2, typeof(WestPosition))]
        [TestCase("MMM", 2, 0, typeof(SouthPosition))]
        [TestCase("LLMMM", 2, 5, typeof(NorthPosition))]
        [TestCase("RMMLMLM", 1, 1, typeof(EastPosition))]
        public void Move_SouthPosition_should_update_the_position(string commands, int x, int y, Type positionType)
        {
            _position = new SouthPosition(new Point(2, 2));
            _robot = new Robot.Robot(_position, _arena);
            _robot.AddMoveCommand(commands);

            _robot.Move();

            Assert.AreEqual(positionType, _robot.Position.GetType());
            Assert.AreEqual(x, _robot.Position.Point.X);
            Assert.AreEqual(y, _robot.Position.Point.Y);
        }

        [TestCase("LLRM", 2, 3, typeof(NorthPosition))]
        [TestCase("LLLMM", 2, 0, typeof(SouthPosition))]
        [TestCase("MMM", 5, 2, typeof(EastPosition))]
        [TestCase("LLMMM", 0, 2, typeof(WestPosition))]
        [TestCase("RMMLMLM", 3, 1, typeof(NorthPosition))]
        public void Move_EastPosition_should_update_the_position(string commands, int x, int y, Type positionType)
        {
            _position = new EastPosition(new Point(2, 2));
            _robot = new Robot.Robot(_position, _arena);
            _robot.AddMoveCommand(commands);

            _robot.Move();

            Assert.AreEqual(positionType, _robot.Position.GetType());
            Assert.AreEqual(x, _robot.Position.Point.X);
            Assert.AreEqual(y, _robot.Position.Point.Y);
        }

        
    }
}