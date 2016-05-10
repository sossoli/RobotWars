using RobotWars.Positions;

namespace RobotWars.Arena
{
    public class ArenaFactory : IArenaFactory
    {
        public IArena Create(string command)
        {
            var arguments = command.Split(' ');
            var width = int.Parse(arguments[0]);
            var height = int.Parse(arguments[1]);
            return new Arena(new Size(width, height));
        }
    }
}