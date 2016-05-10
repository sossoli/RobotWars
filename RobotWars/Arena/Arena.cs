using RobotWars.Positions;

namespace RobotWars.Arena
{
    public class Arena : IArena
    {
        private Size _size;

        public Arena(Size size)
        {
            _size = size;
        }

        public Size GetSize()
        {
            return _size;
        }

        public bool IsValid(Point point)
        {
            var isValidX = point.X >= 0 && point.X <= _size.Width;
            var isValidY = point.Y >= 0 && point.Y <= _size.Height;
            return isValidX && isValidY;
        }
    }
}