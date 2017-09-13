using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board, Square currentSquare)
        {
            List<Square> squares = new List<Square>();
            int[,] ls = new int[8, 2] { { 1, 2 }, { 2, 1 }, { -1, 2 }, { 2, -1 }, { -2, 1 }, { 1, -2 }, { -1, -2 }, { -2, -1 } };
            for (int i = 0; i < 8; i++)
            {
                squares.Add(new Square(currentSquare.Row + ls[i, 0], currentSquare.Col + ls[i, 1]));
            }
            squares.RemoveAll(s => !Board.IsSquareInBounds(s));
            return squares;
        }
        /*
        private IEnumerable<Square> GetAllLMoves(Square currentSquare)
        {
           
        }
        */
    }
}