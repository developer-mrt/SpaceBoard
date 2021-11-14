using SpaceBoard.Core.Base.Boards;
using SpaceBoard.Core.Base.Devices.Rovers;
using SpaceBoard.Core.Base.Directions;
using SpaceBoard.Core.Base.Movements;
using SpaceBoard.Core.Infrastructure;
using SpaceBoard.Core.Validators.Boards;
using SpaceBoard.Core.Validators.Devices;
using SpaceBoard.Services.Boards;
using SpaceBoard.Services.Devices.Rovers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBoard.Services.Common
{
    /// <summary>
    /// Represents the concrete class of the command parser service
    /// </summary>
    public class CommandParserService : ICommandParserService
    {
        #region Fields
        private readonly IDeviceValidator _deviceValidator;
        private readonly IBoardValidator _boardValidator;
        #endregion

        #region Ctor
        public CommandParserService(IDeviceValidator deviceValidator,
            IBoardValidator boardValidator)
        {
            _deviceValidator = deviceValidator;
            _boardValidator = boardValidator;
        }
        #endregion

        #region Utilities
        private ICommand ParseBoardSetCommand(string instruction)
        {
            // Sample instruction input: "5 4"
            var instructions = instruction.Split(' '); // 5, 4
            var x = int.Parse(instructions[0]); // 5
            var y = int.Parse(instructions[1]); // 4

            return new BoardSetCommand(new Size(x, y));
        }

        private ICommand ParseRoverSetCommand(string instruction)
        {
            // Sample instruction input: "1 2 N"
            var instructions = instruction.Split(' '); // 1, 2, N
            var x = int.Parse(instructions[0]); // 1
            var y = int.Parse(instructions[1]); // 2
            var directionString = instructions[2][0]; // N

            return new RoverSetCommand(new RoverPoint(x, y, (Direction)directionString));
        }

        private ICommand ParseRoverMoveCommand(string instruction)
        {
            // Sample instruction input: "R M L M M"
            var instructions = instruction.Split(' ');

            string ParseToEnumName(string value)
            {
                switch (value)
                {
                    case "M":
                        return "Move";
                    case "R":
                        return "Right";
                    case "L":
                        return "Left";
                    default:
                        throw new ApplicationException($"'{value}' is not a valid instruction");
                }
            }

            var moves = instructions.Select(move => Enum.Parse<Movement>(ParseToEnumName(move))).ToList();

            return new RoverMoveCommand(moves);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Parses all instructions and returns the command interface list.
        /// </summary>
        /// <param name="instructions">String</param>
        /// <returns>Commands</returns>
        public IEnumerable<ICommand> Parse(string instructions, int startIndex)
        {
            if (string.IsNullOrWhiteSpace(instructions))
                throw new ArgumentNullException(null, "Instructions parameter cannot be null or empty");

            var instructionLines = instructions.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            if (instructionLines.Length < SettingsDefaults.MinimumFormatLength)
                throw new ArgumentException($"The length of the settings cannot be lower than minimum length {SettingsDefaults.MinimumFormatLength}");

            var commands = new List<ICommand>();

            #region Line 1: The first line should define the board size

            var boardSize = instructionLines[0];
            _boardValidator.IsValidBoardSize(boardSize);

            commands.Add(ParseBoardSetCommand(boardSize));


            #endregion

            #region Line 2: The second line of the file should contain the starting position of the rover.

            var roverStartingPosition = instructionLines[startIndex];
            var directions = Enum.GetValues(typeof(Direction)).Cast<Direction>().Select(x => x.ToString()).ToList();
            _deviceValidator.IsValidDeviceStartingPoint(directions, roverStartingPosition);

            commands.Add(ParseRoverSetCommand(roverStartingPosition));

            #endregion

            #region Line 3: The thirth line to the end of the file should contain a series of moves.

            var movementInstructions = new StringBuilder();

            var instructionLine = instructionLines.Skip(startIndex + 1).FirstOrDefault();

            var movements = Enum.GetValues(typeof(Movement)).Cast<Movement>().Select(x => x.ToString()).ToList();
            _deviceValidator.IsValidDeviceMovements(movements, instructionLine);

            movementInstructions.AppendFormat("{0} ", instructionLine);

            if (!string.IsNullOrEmpty(movementInstructions.ToString()))
            {
                commands.Add(ParseRoverMoveCommand(movementInstructions.ToString().Trim()));
            }

            #endregion

            return commands;
        }
        #endregion
    }
}
