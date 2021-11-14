using SpaceBoard.Core.Base.Boards;
using SpaceBoard.Core.Infrastructure;
using SpaceBoard.Services.Boards;
using SpaceBoard.Services.Devices.Rovers;
using SpaceBoard.Services.Devices.Rovers.Commands;
using SpaceBoard.Services.Initializations;
using System.Collections.Generic;

namespace SpaceBoard.Services.Common
{
    /// <summary>
    /// Represents the concrete class of the rover invoker
    /// </summary>
    public class RoverInvoker : IInvoker
    {
        #region Fields
        private readonly IBoard _board;
        private readonly IRover _rover;
        private readonly IInitializationService<IRover> _initializationService;
        private IEnumerable<ICommand> _commands;
        #endregion

        #region CtOr
        public RoverInvoker(IBoard board,
            IRover rover,
            IInitializationService<IRover> initializationService)
        {
            _board = board;
            _rover = rover;
            _initializationService = initializationService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set commands
        /// </summary>
        /// <param name="commands">Commands</param>
        public void SetCommands(IEnumerable<ICommand> commands)
        {
            _commands = commands;
        }
        #endregion

        /// <summary>
        /// Invoke commands
        /// </summary>
        public void InvokeCommands()
        {
            foreach (var command in _commands)
            {
                var name = command.GetType().GetInterfaces()[0].Name;
                switch (name)
                {
                    case nameof(IBoardSetCommand):
                        _initializationService.InitializationBoardSetCommand(_board, command);
                        break;

                    case nameof(IRoverSetCommand):
                        _initializationService.InitializationDeviceSetCommand(_board, _rover, command);
                        break;

                    case nameof(IRoverMoveCommand):
                        _initializationService.InitializationDeviceMoveCommand(_rover, command);
                        break;
                }
                command.Execute();
            }
        }

        /// <summary>
        /// Get result
        /// </summary>
        /// <returns></returns>
        public string GetResult()
        {
            return $"{_rover.Point.X} {_rover.Point.Y} {_rover.Point.Direction.ToString().Substring(0, 1)}";
        }
    }
}
