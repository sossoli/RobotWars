using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RobotWars.Commands
{
    public class CommandMatcher : ICommandMatcher
    {
        private IDictionary<string, CommandType> _commandTypeDictionary;

        public CommandMatcher() 
        {
            Init();
        }

        public CommandType GetCommandType(string command)
        {
            try
            {
                var commandType = _commandTypeDictionary.First(regexToCommandType => new Regex(regexToCommandType.Key).IsMatch(command));
                return commandType.Value;
            }
            catch (InvalidOperationException e)
            {
                var exceptionMessage = String.Format("'{0}' is not a valid command", command);
                throw new Exception(exceptionMessage, e);
            }
        }

        private void Init()
        {
            _commandTypeDictionary = new Dictionary<string, CommandType>
            {
                { @"^\d+ \d+$", CommandType.ArenaCommand },
                { @"^\d+ \d+ [NSEW]$", CommandType.SetRobotCommand},
                { @"^[LRM]+$", CommandType.MoveRobotCommand }
            };
        }
    }
}