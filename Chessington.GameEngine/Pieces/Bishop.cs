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
            //validSquares.RemoveAll(s => !Board.IsSquareInBounds(s));
            validSquares.RemoveAll(s => s == currentSquare);
            validSquares.RemoveAll(s => board.isPieceDirectlyBetweenDiagonalExclusive(currentSquare, s));
            return validSquares;
        }

        
    }
}