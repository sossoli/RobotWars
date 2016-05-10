namespace RobotWars.Positions
{
    public class SouthPosition : PositionBase, IPosition
    {
        public SouthPosition(Point point) : base(point)
        {
            _orientation = "S";
        }

        protected override IPosition LeftMovement()
        {
            return new EastPosition(_point);
        }

        protected override IPosition RightMovement()
        {
            return new WestPosition(_point);
        }

        protected override IPosition ForewardMovement()
        {
            return new SouthPosition(new Point(_point.X, _point.Y -1));
        }
    }
}