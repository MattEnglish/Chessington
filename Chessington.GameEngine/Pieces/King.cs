using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board, Square currentSquare)
        {
            var squares = new List<Square>();
            for (int row = -1; row <=1 ; row++)
            {
                for (int col = -1; col <= 1; col++)
                {
                    squares.Add(new Square(currentSquare.Row+row,currentSquare.Col + col));
                }               
            }
            squares.Remove(currentSquare);
            squares.RemoveAll(s => !Board.IsSquareInBounds(s));
            return squares;
        }
    }
}