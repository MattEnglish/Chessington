using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var squares = new List<Square>();

            for (int row = 0; row < 8; row++)
            {
                if (row != currentSquare.Row)
                {
                    squares.Add(new Square(row, currentSquare.Col));
                }
            }
            for (int col = 0; col < 8; col++)
            {
                if (col != currentSquare.Row)
                {
                    squares.Add(new Square(currentSquare.Row, col));
                }
            }
            return squares;
        }
    }
}