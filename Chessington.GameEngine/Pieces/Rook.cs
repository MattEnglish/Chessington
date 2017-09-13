using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board, Square currentSquare)
        {
            
            var squares = new List<Square>();
            squares.AddRange(base.GetSquaresInRow(currentSquare));
            squares.AddRange(base.GetSquaresInCol(currentSquare));
            squares.RemoveAll(s => s == currentSquare);
            squares.RemoveAll(s => board.isPieceDirectlyBetweenHorizontalOrVerticalExclusive(currentSquare, s));
            
            return squares;
        }
    }
}