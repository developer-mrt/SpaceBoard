namespace SpaceBoard.Services.Devices.Rovers.Commands
{
    /// <summary>
    /// Represents the contract of rover move <see cref="IDeviceMoveCommand{TDevice}"/>
    /// </summary>
    public interface IRoverMoveCommand : IDeviceMoveCommand<IRover>
    {
    }
}
