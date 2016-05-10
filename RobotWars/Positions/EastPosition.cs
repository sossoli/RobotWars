namespace RobotWars.Positions
{
    public class EastPosition : PositionBase, IPosition
    {
        public EastPosition(Point point) : base(point)
        {
            _orientation = "E";
        }

        protected override IPosition LeftMovement()
        {
            return new NorthPosition(_point);
        }

        protected override IPosition RightMovement()
        {
            return new SouthPosition(_point);
        }

        protected override IPosition ForewardMovement()
        {
            return new EastPosition(new Point(_point.X +1, _point.Y));
        }
    }
}