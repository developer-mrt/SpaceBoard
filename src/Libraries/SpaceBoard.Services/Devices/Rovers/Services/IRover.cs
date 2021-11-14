using SpaceBoard.Core.Base.Boards;
using SpaceBoard.Core.Base.Devices;
using SpaceBoard.Core.Base.Devices.Rovers;
using SpaceBoard.Core.Base.Movements;
using System.Collections.Generic;

namespace SpaceBoard.Services.Devices.Rovers
{
    /// <summary>
    /// Represents the contract of rover <see cref="IDevice"/>
    /// </summary>
    public interface IRover: IDevice
    {
        /// <summary>
        /// Gets or sets the value of rover point
        /// </summary>
        RoverPoint Point { get; set; }

        /// <summary>
        /// Gets or sets the value of result 
        /// </summary>
        string Result { get; set; }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="point">Rover point</param>
        void Set(IBoard board, RoverPoint point);

        /// <summary>
        /// Move
        /// </summary>
        /// <param name="movements">Movement</param>
        void Move(IEnumerable<Movement> movements);
    }
}
