using SpaceBoard.Core.Base.Boards;
using SpaceBoard.Core.Infrastructure;

namespace SpaceBoard.Services.Boards
{
    /// <summary>
    /// Represents the conctract of board set command <see cref="ICommand"/>
    /// </summary>
    public interface IBoardSetCommand : ICommand
    {
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        void Set(IBoard board);

    }
}
