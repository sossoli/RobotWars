using System;
using System.Collections.Generic;

namespace RobotWars.Positions
{
    public abstract class PositionBase
    {
        protected Point _point;
        protected string _orientation;
        private readonly Dictionary<char, Func<IPosition>> _commandDictionary;

        public Point Point { get { return _point; } }

        protected PositionBase(Point point)
        {
            _point = point;
            _commandDictionary = new Dictionary<char, Func<IPosition>>()
            {
                {'L', LeftMovement},
                {'R', RightMovement},
                {'M', ForewardMovement},
            };
        }

        protected abstract IPosition LeftMovement();
        protected abstract IPosition RightMovement();
        protected abstract IPosition ForewardMovement();

        public IPosition Execute(char command)
        {
            return _commandDictionary[command].Invoke();
        }

        public override string ToString()
        {
            return string.Format(_point + " {0}", _orientation);
        }
    }
}