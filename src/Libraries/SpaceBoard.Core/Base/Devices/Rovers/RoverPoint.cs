using SpaceBoard.Core.Base.Directions;
using SpaceBoard.Core.Base.Points;

namespace SpaceBoard.Core.Base.Devices.Rovers
{
    /// <summary>
    /// Represents rover locale point on the board
    /// </summary>
    public class RoverPoint : IPoint
    {
        #region Ctor
        public RoverPoint(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the value of X
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Gets or sets the value of Y
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Gets or sets the value of direction
        /// </summary>
        public Direction Direction { get; set; }
        #endregion
    }
}
