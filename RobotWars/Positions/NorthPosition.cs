namespace RobotWars.Positions
{
    public class NorthPosition : PositionBase, IPosition
    {
        public NorthPosition(Point point) :base(point)
        {
            _orientation = "N";
        }

        protected override IPosition LeftMovement()
        {
            return new WestPosition(_point);
        }

        protected override IPosition RightMovement()
        {
            return new EastPosition(_point);
        }

        protected override IPosition ForewardMovement()
        {
            return new NorthPosition(new Point(_point.X, _point.Y + 1));
        }
    }
}