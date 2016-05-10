using NUnit.Framework;
using RobotWars.Arena;

namespace RobotWars.Test.ArenaTests
{
    [TestFixture]
    public class ArenaFactoryTest
    {
        private IArenaFactory _factory;

        public ArenaFactoryTest()
        {
            _factory = new ArenaFactory();
        }

        [Test]
        public void Create_shoud_return_new_arena_with_correct_height_and_width()
        {
            IArena arena = _factory.Create("3 7");

            Assert.AreEqual(3, arena.GetSize().Width);
            Assert.AreEqual(7, arena.GetSize().Height);
        }
    }
}