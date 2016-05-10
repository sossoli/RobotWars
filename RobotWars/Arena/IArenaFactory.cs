namespace RobotWars.Arena
{
    public interface IArenaFactory
    {
        IArena Create(string command);
    }
}