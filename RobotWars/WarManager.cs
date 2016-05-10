using System;
using System.Collections.Generic;
using System.Linq;
using RobotWars.Arena;
using RobotWars.Commands;
using RobotWars.Robot;

namespace RobotWars
{
    public class WarManager : IWarManager
    {
        private IArena _arena;
        private readonly ICommandMatcher _commandMatcher;
        private readonly Dictionary<CommandType, Action<string>> _commandParserDictionary;
        private readonly IArenaFactory _arenaFactory;
        private readonly List<IRobot> _robotList;
        private readonly IRobotFactory _robotFactory;

        public IArena Arena { get { return _arena; } }
        public List<IRobot> Robots { get { return _robotList; } }

        public WarManager()
        {
            _robotList = new List<IRobot>();
            _commandMatcher = new CommandMatcher();
            _arenaFactory = new ArenaFactory();
            _robotFactory = new RobotFactory();
            _commandParserDictionary = new Dictionary<CommandType, Action<string>>
            {
                {CommandType.ArenaCommand, SetupArena},
                {CommandType.SetRobotCommand, SetupRobot},
                {CommandType.MoveRobotCommand, AssignMoveCommand}
            };
        }

        private void AssignMoveCommand(string command)
        {
            _robotList.Last().AddMoveCommand(command);
        }

        private void SetupRobot(string command)
        {
            _robotList.Add(_robotFactory.Create(command, _arena));
        }

        private void SetupArena(string command)
        {
            _arena = _arenaFactory.Create(command);
        }

        public void Init(string command)
        {
            var commands = command.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            commands.ForEach(c => _commandParserDictionary[_commandMatcher.GetCommandType(c)].Invoke(c));
        }

        public string GetOutput()
        {
            return string.Join(Environment.NewLine, _robotList.Select(x => x.Position.ToString()));
        }

        public void Run()
        {
            _robotList.ForEach(r => r.Move());
        }
    }
}