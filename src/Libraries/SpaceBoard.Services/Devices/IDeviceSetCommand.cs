using SpaceBoard.Core.Base.Boards;
using SpaceBoard.Core.Base.Devices;
using SpaceBoard.Core.Infrastructure;

namespace SpaceBoard.Services.Devices
{
    /// <summary>
    /// Generic device set command of <see cref="ICommand">
    /// </summary>
    /// <typeparam name="TDevice">Device</typeparam>
    public interface IDeviceSetCommand<TDevice>  : ICommand where TDevice : IDevice
    {
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="device">Device</param>
        void Set(IBoard board, TDevice device);
    }
}
