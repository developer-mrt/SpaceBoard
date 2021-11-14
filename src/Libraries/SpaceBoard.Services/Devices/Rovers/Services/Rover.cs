using SpaceBoard.Core.Base.Boards;
using SpaceBoard.Core.Base.Devices.Rovers;
using SpaceBoard.Core.Base.Movements;
using SpaceBoard.Core.Exceptions;
using System.Collections.Generic;

namespace SpaceBoard.Services.Devices.Rovers.Services
{
    /// <summary>
    /// Represents the concrete class of the rover
    /// </summary>
    public class Rover : IRover
    {
        #region Fields
        private readonly IRoverMoveService _roverMoveService;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the board
        /// </summary>
        private IBoard Board { get; set; }

        /// <summary>
        /// Gets or sets the value of rover point
        /// </summary>
        public RoverPoint Point { get; set; }

        /// <summary>
        /// Gets or sets the value of result 
        /// </summary>
        public string Result { get; set; }
        #endregion

        #region CtOr
        public Rover(IRoverMoveService roverMoveService)
        {
            _roverMoveService = roverMoveService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="point">Rover point</param>
        public void Set(IBoard board, RoverPoint point)
        {
            if (board.IsValid(point))
                Point = point;
            else
                throw new PointValidationException("Rover point is not valid!");

            Board = board;
        }

        /// <summary>
        /// Move
        /// </summary>
        /// <param name="movements">Movement</param>
        public void Move(IEnumerable<Movement> movements)
        {
            foreach (var movement in movements)
            {
                if (movement == Movement.Move)
                {
                    // Make sure the rover still in the board.
                    if (!Board.IsValid(Point))
                        throw new PointValidationException("Rover cannot go out of board!");

                    // Move the rover to the next tile.
                    _roverMoveService.MoveForward(Point);
                }
                else if (movement == Movement.Left)
                {
                    // Turn left the rover.
                    _roverMoveService.MoveLeft(Point);
                }
                else if (movement == Movement.Right)
                {
                    // Turn right the rover.
                    _roverMoveService.MoveRight(Point);
                }
            }
        }
        #endregion
    }
}
