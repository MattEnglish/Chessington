using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board, Square currentSquare)
        {
            var squares = new List<Square>();
            squares.AddRange(base.HorizontalSquares(currentSquare));
            squares.AddRange(base.VerticalSquares(currentSquare));
            squares.RemoveAll(s => s == currentSquare);
            return squares;
        }
    }
}