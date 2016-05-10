using NUnit.Framework;
using RobotWars.Positions;

namespace RobotWars.Test.PositionsTests
{
    [TestFixture]
    public class SouthPositionTest
    {
        private IPosition _position;

        public SouthPositionTest()
        {
            _position = new SouthPosition(new Point(0, 0));
        }

        [Test]
        public void Execute_L_command_should_return_EastPosition_with_same_point()
        {
            IPosition newPos = _position.Execute('L');

            Assert.AreEqual(typeof(EastPosition), newPos.GetType());
            Assert.AreEqual(newPos.Point, _position.Point);
        }

        [Test]
        public void Execute_R_command_should_return_WestPosition_with_same_point()
        {
            IPosition newPos = _position.Execute('R');

            Assert.AreEqual(typeof(WestPosition), newPos.GetType());
            Assert.AreEqual(newPos.Point, _position.Point);
        }

        [Test]
        public void Execute_M_command_should_return_WestPosition_with_Y_decremented()
        {
            IPosition newPos = _position.Execute('M');

            Assert.AreEqual(typeof(SouthPosition), newPos.GetType());
            Assert.AreEqual(newPos.Point.Y, _position.Point.Y -1);
            Assert.AreEqual(newPos.Point.X, _position.Point.X);
        }
    }
}