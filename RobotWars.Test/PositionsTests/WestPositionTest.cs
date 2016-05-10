using NUnit.Framework;
using RobotWars.Positions;

namespace RobotWars.Test.PositionsTests
{
    [TestFixture]
    public class WestPositionTest
    {
        private IPosition _position;

        public WestPositionTest()
        {
            _position = new WestPosition(new Point(0, 0));
        }

        [Test]
        public void Execute_L_command_should_return_SouthPosition_with_same_point()
        {
            IPosition newPos = _position.Execute('L');

            Assert.AreEqual(typeof(SouthPosition), newPos.GetType());
            Assert.AreEqual(newPos.Point, _position.Point);
        }

        [Test]
        public void Execute_R_command_should_return_NorthPosition_with_same_point()
        {
            IPosition newPos = _position.Execute('R');

            Assert.AreEqual(typeof(NorthPosition), newPos.GetType());
            Assert.AreEqual(newPos.Point, _position.Point);
        }

        [Test]
        public void Execute_M_command_should_return_WestPosition_with_X_decremented()
        {
            IPosition newPos = _position.Execute('M');

            Assert.AreEqual(typeof(WestPosition), newPos.GetType());
            Assert.AreEqual(newPos.Point.Y, _position.Point.Y);
            Assert.AreEqual(newPos.Point.X, _position.Point.X -1);
        }
    }
}