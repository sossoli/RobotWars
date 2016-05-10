using NUnit.Framework;
using RobotWars.Positions;

namespace RobotWars.Test.ArenaTests
{
    [TestFixture]
    public class ArenaTest
    {
        private Arena.Arena _arena;

        [TestCase(1, 6, false)]
        [TestCase(1, 5, true)]
        [TestCase(0, 0, true)]
        [TestCase(-1, 0, false)]
        [TestCase(6, 0, false)]
        [TestCase(5, 5, true)]
        public void IsValid_should_return_if_a_point_is_in_arena_range(int x, int y, bool expected)
        {
            _arena = new Arena.Arena(new Size(5, 5));

            Assert.AreEqual(expected, _arena.IsValid(new Point(x, y)));
        }
        
    }
}