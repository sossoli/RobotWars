namespace RobotWars.Positions
{
    public class WestPosition : PositionBase, IPosition
    {
        public WestPosition(Point point) : base(point)
        {
            _orientation = "W";
        }

        protected override IPosition LeftMovement()
        {
            return new SouthPosition(_point);
        }

        protected override IPosition RightMovement()
        {
            return new NorthPosition(_point);
        }

        protected override IPosition ForewardMovement()
        {
            return new WestPosition(new Point( _point.X -1, _point.Y));
        }
    }
}