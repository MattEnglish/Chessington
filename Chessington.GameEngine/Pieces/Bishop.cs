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
            
            var validSquares = new List<Square>();


            for (var i = -7; i < 8; i++)
            {
                
                    validSquares.Add(Square.At(currentSquare.Row + i, currentSquare.Col + i));
                

            }
            for (var i = -7; i < 8; i++)
            {
                    validSquares.Add(Square.At(currentSquare.Row + i, currentSquare.Col - i));
                
            }

            validSquares.RemoveAll(s => !board.IsSquareInBounds(s));
            validSquares.RemoveAll(s => s == currentSquare);
            return validSquares;
        }

        
    }
}