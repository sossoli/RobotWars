using System;
using System.CodeDom;
using NUnit.Framework;
using RobotWars.Positions;
using RobotWars.Robot;

namespace RobotWars.Test.RobotTests
{
    [TestFixture]
    public class RobotFactoryTest
    {
        private RobotFactory _factory;

        public RobotFactoryTest()
        {
            _factory = new RobotFactory();
        }

        [TestCase("1 2 N", 1, 2, typeof(NorthPosition))]
        [TestCase("1 2 S", 1, 2, typeof(SouthPosition))]
        [TestCase("1 2 W", 1, 2, typeof(WestPosition))]
        [TestCase("1 2 E", 1, 2, typeof(EastPosition))]
        public void Create_should_create_the_robit_withCorrect_Position_and_arena(string command, int x, int y, Type posType)
        {
            Arena.Arena arena = new Arena.Arena(new Size(5, 5));
            IRobot robot = _factory.Create(command, arena);

            Assert.AreEqual(x, robot.Position.Point.X);
            Assert.AreEqual(y, robot.Position.Point.Y);
            Assert.AreEqual(posType, robot.Position.GetType());
            Assert.AreEqual(arena, robot.GetArena());
        }


    }
}