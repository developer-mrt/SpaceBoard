using SpaceBoard.Core.Base.Boards;
using SpaceBoard.Core.Base.Devices;
using SpaceBoard.Core.Infrastructure;

namespace SpaceBoard.Services.Initializations
{
    /// <summary>
    /// Represents the conctract of initialization service
    /// </summary>
    /// <typeparam name="T">Device</typeparam>
    public interface IInitializationService<T>
        where T : IDevice
    {
        /// <summary>
        /// Initialization Board Set Command
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="command">Command</param>
        void InitializationBoardSetCommand(IBoard board, ICommand command);

        /// <summary>
        /// Initialization Device Set Command
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="device">Device</param>
        /// <param name="command">Command</param>
        void InitializationDeviceSetCommand(IBoard board, T device, ICommand command);

        /// <summary>
        /// Initializatiob device move command
        /// </summary>
        /// <param name="device">Device</param>
        /// <param name="command">Command</param>
        void InitializationDeviceMoveCommand(T device, ICommand command);
    }
}
