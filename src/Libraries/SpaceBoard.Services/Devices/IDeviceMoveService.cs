using SpaceBoard.Core.Base.Devices;
using SpaceBoard.Core.Base.Points;
using System.Collections.Generic;

namespace SpaceBoard.Services.Devices
{
    /// <summary>
    /// Represents the contract of device move
    /// </summary>
    /// <typeparam name="TDevice">Device</typeparam>
    public interface IDeviceMoveService<TDevice>
        where TDevice : IDevice
    {

    }
}
