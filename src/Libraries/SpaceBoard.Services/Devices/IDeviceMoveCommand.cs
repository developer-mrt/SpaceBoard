using SpaceBoard.Core.Base.Devices;
using SpaceBoard.Core.Base.Movements;
using SpaceBoard.Core.Infrastructure;
using System.Collections.Generic;

namespace SpaceBoard.Services.Devices
{
    /// <summary>
    /// Generic device move command of <see cref="ICommand"/>
    /// </summary>
    /// <typeparam name="TDevice">Device</typeparam>
    public interface IDeviceMoveCommand<TDevice> : ICommand
        where TDevice : IDevice
    {
        /// <summary>
        /// Gets or sets the value of movements
        /// </summary>
        IList<Movement> Movements { get; set; }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="device">Device</param>
        void Set(TDevice device);
    }
}
