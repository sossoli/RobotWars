namespace RobotWars
{
    public interface IWarManager
    {
        void Init(string command);
        string GetOutput();
        void Run();
    }
}