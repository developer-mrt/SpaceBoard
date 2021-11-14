using SpaceBoard.Core.Base.Devices.Rovers;
using SpaceBoard.Core.Base.Directions;

namespace SpaceBoard.Services.Devices.Rovers
{
    /// <summary>
    /// Represents the concrete class of the rover move service
    /// </summary>
    public class RoverMoveService : IRoverMoveService
    {
        #region Methods

        /// <summary>
        /// Move Forward
        /// </summary>
        /// <param name="point">Rover point</param>
        public void MoveForward(RoverPoint point)
        {
            switch (point.Direction)
            {
                case Direction.North:
                    point.Y += 1;
                    break;
                case Direction.West:
                    point.X -= 1;
                    break;
                case Direction.South:
                    point.Y -= 1;
                    break;
                case Direction.East:
                    point.X += 1;
                    break;
            }
        }

        /// <summary>
        /// Move Left
        /// </summary>
        /// <param name="point">Rover point</param>
        public void MoveLeft(RoverPoint point)
        {
            switch (point.Direction)
            {
                case Direction.North:
                    point.Direction = Direction.West;
                    break;
                case Direction.West:
                    point.Direction = Direction.South;
                    break;
                case Direction.South:
                    point.Direction = Direction.East;
                    break;
                case Direction.East:
                    point.Direction = Direction.North;
                    break;
            }
        }

        /// <summary>
        /// Move Right
        /// </summary>
        /// <param name="point">Rover point</param>
        public void MoveRight(RoverPoint point)
        {
            switch (point.Direction)
            {
                case Direction.North:
                    point.Direction = Direction.East;
                    break;
                case Direction.East:
                    point.Direction = Direction.South;
                    break;
                case Direction.South:
                    point.Direction = Direction.West;
                    break;
                case Direction.West:
                    point.Direction = Direction.North;
                    break;
            }
        }
        #endregion
    }
}
