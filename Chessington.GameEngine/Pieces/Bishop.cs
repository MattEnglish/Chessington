using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board, Square currentSquare)
        {

            var validSquares = (List<Square>)base.GetSquaresInDiagonal(currentSquare);
            validSquares.RemoveAll(s => s == currentSquare);
            return validSquares;
        }

        
    }
}