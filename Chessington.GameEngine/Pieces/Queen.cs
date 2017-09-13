using System.Collections.Generic;
using System.ComponentModel.Design;
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
            squares.AddRange(base.GetSquaresInRow(currentSquare));
            squares.AddRange(base.GetSquaresInCol(currentSquare));
            squares.AddRange(base.GetSquaresInDiagonal(currentSquare));
            squares.RemoveAll(s => s == currentSquare);
            squares.RemoveAll(s => board.isPieceDirectlyBetweenHorizontalOrVerticalExclusive(currentSquare, s));
            squares.RemoveAll(s => board.isPieceDirectlyBetweenDiagonalExclusive(currentSquare, s));
            return squares;
        }
    }
}