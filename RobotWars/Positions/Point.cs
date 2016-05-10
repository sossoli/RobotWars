using System.Runtime.Remoting.Messaging;

namespace RobotWars.Positions
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            Point point = ((Point)obj);
            return  X == point.X && Y == point.Y;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", X, Y);
        }
    }
}