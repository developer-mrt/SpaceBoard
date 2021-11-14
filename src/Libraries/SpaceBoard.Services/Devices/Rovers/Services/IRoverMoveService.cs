using SpaceBoard.Core.Base.Devices.Rovers;

namespace SpaceBoard.Services.Devices.Rovers
{
    /// <summary>
    /// Represents the contract of rover move service <see cref="IDeviceMoveService{TDevice, YObstacle}"/>
    /// </summary>
    public interface IRoverMoveService : IDeviceMoveService<IRover>
    {
        /// <summary>
        /// Move Forward
        /// </summary>
        /// <param name="point">Rover point</param>
        void MoveForward(RoverPoint point);

        /// <summary>
        /// Move Left
        /// </summary>
        /// <param name="point">Rover point</param>
        void MoveLeft(RoverPoint point);

        /// <summary>
        /// Move Right
        /// </summary>
        /// <param name="point">Rover point</param>
        void MoveRight(RoverPoint point);
    }
}
