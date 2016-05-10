using System;
using NUnit.Framework;
using RobotWars.Commands;

namespace RobotWars.Test.CommandTests
{
    [TestFixture]
    public class CommandMatcherTest
    {
        private readonly ICommandMatcher _commandMatcher;

        public CommandMatcherTest()
        {
            _commandMatcher = new CommandMatcher();
        }

        [TestCase("0 0", CommandType.ArenaCommand)]
        [TestCase("10 20", CommandType.ArenaCommand)]
        [TestCase("10 20 W", CommandType.SetRobotCommand)]
        [TestCase("10 20 S", CommandType.SetRobotCommand)]
        [TestCase("10 20 N", CommandType.SetRobotCommand)]
        [TestCase("10 20 E", CommandType.SetRobotCommand)]
        [TestCase("LMRMM", CommandType.MoveRobotCommand)]
        [TestCase("LLRRLLRR", CommandType.MoveRobotCommand)]
        [TestCase("LRMLRM", CommandType.MoveRobotCommand)]
        public void Valid_command_returns_command_type(string command, CommandType expectedCommand)
        {
            var commandType = _commandMatcher.GetCommandType(command);
            Assert.AreEqual(expectedCommand, commandType);
        }
        
    }
}
