namespace RobotWars.Commands
{
    public interface ICommandMatcher
    {
        CommandType GetCommandType(string command);
    }
}