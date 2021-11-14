using SpaceBoard.Core.Base.Boards;
using SpaceBoard.Core.Infrastructure;
using SpaceBoard.Services.Boards;
using SpaceBoard.Services.Devices.Rovers;
using SpaceBoard.Services.Devices.Rovers.Commands;

namespace SpaceBoard.Services.Initializations
{
    /// <summary>
    /// Represents the concrete class of the rover initialization service
    /// </summary>
    public class RoverInitializationService : IInitializationService<IRover>
    {
        #region Methods
        /// <summary>
        /// Initialization Board Set Command
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="command">Command</param>
        public void InitializationBoardSetCommand(IBoard board, ICommand command)
        {
            var boardSetCommand = (IBoardSetCommand)command;
            boardSetCommand.Set(board);
        }


        /// <summary>
        /// Initialization Device Set Command
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="rover">Rover</param>
        /// <param name="command">Command</param>
        public void InitializationDeviceSetCommand(IBoard board, IRover rover, ICommand command)
        {
            var roverSetCommand = (IRoverSetCommand)command;
            roverSetCommand.Set(board, rover);
        }

        /// <summary>
        /// Initializatiob device move command
        /// </summary>
        /// <param name="rover">Device</param>
        /// <param name="command">Command</param>
        public void InitializationDeviceMoveCommand(IRover rover, ICommand command)
        {
            var roverMoveCommand = (IRoverMoveCommand)command;
            roverMoveCommand.Set(rover);
        }
        #endregion

    }
}
