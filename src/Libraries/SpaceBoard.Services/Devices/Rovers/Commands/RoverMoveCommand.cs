using SpaceBoard.Core.Base.Movements;
using System.Collections.Generic;

namespace SpaceBoard.Services.Devices.Rovers.Commands
{
    /// <summary>
    /// Represents the concrete class of the rover move command
    /// </summary>
    public class RoverMoveCommand : IRoverMoveCommand
    {
        #region Fields
        private IRover _rover;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the value of movements
        /// </summary>
        public IList<Movement> Movements { get; set; }

        #endregion

        #region CtOr
        public RoverMoveCommand(IList<Movement> movements)
        {
            Movements = movements;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Execute
        /// </summary>
        public void Execute()
        {
            _rover.Move(Movements);
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="rover">Rover</param>
        public void Set(IRover rover)
        {
            _rover = rover;
        }
        #endregion

    }
}
