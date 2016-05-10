using System;
using System.Text;

namespace RobotWars
{
    class Program
    {

        static void Main(string[] args)
        {
            WarManager warManager = new WarManager();
            string initialCommands = CreateCommand();
            warManager.Init(initialCommands);
            warManager.Run();
            Console.WriteLine("Input :");
            Console.WriteLine(initialCommands);
            Console.WriteLine("Output:");
            Console.WriteLine(warManager.GetOutput());
            Console.Write(Environment.NewLine);
            Console.Write("Press something to exit...");
            Console.ReadLine();
        }

        private static string CreateCommand()
        {
            var sb = new StringBuilder();
            sb.AppendLine("5 5");
            sb.AppendLine("1 2 N");
            sb.AppendLine("LMLMLMLMM");
            sb.AppendLine("3 3 E");
            sb.Append("MMRMMRMRRM");
            return sb.ToString();
        }
    }
}
