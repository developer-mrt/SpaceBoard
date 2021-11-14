using SpaceBoard.Core.Base.Devices.Rovers;
using SpaceBoard.Core.Base.Boards;

namespace SpaceBoard.Services.Devices.Rovers.Commands
{
    /// <summary>
    /// Represents the concrete class of the rover set command
    /// </summary>
    public class RoverSetCommand : IRoverSetCommand
    {
        #region Fields
        private readonly RoverPoint _point;
        private IBoard _board;
        private IRover _rover;
        #endregion

        #region CtOr
        public RoverSetCommand(RoverPoint point)
        {
            _point = point;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="rover">Rover</param>
        public void Set(IBoard board, IRover rover)
        {
            _board = board;
            _rover = rover;
        }

        /// <summary>
        /// Execute
        /// </summary>
        public void Execute()
        {
            _rover.Set(_board, _point);
        }
        #endregion

    }
}
