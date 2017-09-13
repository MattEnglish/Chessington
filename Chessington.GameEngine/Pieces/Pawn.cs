using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private Player owner;

        public Pawn(Player player)
            : base(player)
        {
            owner = player;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var squares = new List<Square>();

            if (this.owner == Player.White)
            {
                squares.Add(new Square(currentSquare.Row-1,currentSquare.Col));
            }
            else
            {
                squares.Add(new Square(currentSquare.Row+1, currentSquare.Col));
            }

            return squares;
        }
    }
}