using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RobotWars.Positions;

namespace RobotWars.Test
{
    [TestFixture]
    public class WarManagerTest
    {
        private WarManager _warManager;

        public WarManagerTest()
        {
            _warManager = new WarManager();
        }

        [Test]
        public void Init_ArenaCommand_should_setup_the_arena()
        {
            _warManager.Init("1 3");

            Assert.AreEqual(1, _warManager.Arena.GetSize().Width);
            Assert.AreEqual(3, _warManager.Arena.GetSize().Height);
        }

        [Test]
        public void Init_SetRobotCommand_should_add_a_robot()
        {
            _warManager.Init("1 3 N");

            Assert.AreEqual(1, _warManager.Robots.First().Position.Point.X);
            Assert.AreEqual(3, _warManager.Robots.First().Position.Point.Y);
            Assert.AreEqual(typeof(NorthPosition), _warManager.Robots.First().Position.GetType());
        }

        [Test]
        public void Init_ArenaCommand_and_SetRobotCommand_should_add_a_robot_with_the_crrect_arena()
        {
            StringBuilder sb = new StringBuilder("5 10");
            sb.Append(Environment.NewLine);
            sb.Append("1 3 N");

            _warManager.Init(sb.ToString());

            Assert.AreEqual(1, _warManager.Robots.First().Position.Point.X);
            Assert.AreEqual(3, _warManager.Robots.First().Position.Point.Y);
            Assert.AreEqual(typeof(NorthPosition), _warManager.Robots.First().Position.GetType());
            Assert.AreEqual(5, _warManager.Robots.Last().GetArena().GetSize().Width);
            Assert.AreEqual(10, _warManager.Robots.Last().GetArena().GetSize().Height);
        }

        [Test]
        public void Init_MoveRobotCommand_should_add_the_command_to_the_last_robot()
        {
            StringBuilder sb = new StringBuilder("1 3 N");
            sb.Append(Environment.NewLine);
            sb.Append("LLMRR");

            _warManager.Init(sb.ToString());

            Assert.AreEqual("LLMRR", _warManager.Robots.Last().GetMoveCommands().First());
        }

        [Test]
        public void GetOutput_should_return_the_output_string()
        {
            StringBuilder sb = new StringBuilder("1 3 N");
            sb.Append(Environment.NewLine);
            sb.Append("3 5 W");
            _warManager.Init(sb.ToString());

            string output = _warManager.GetOutput();
            
            Assert.AreEqual(output, sb.ToString());
        }


    }
}