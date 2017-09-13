using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private Player owner;
        private bool hasMoved = false;

        public Pawn(Player player)
            : base(player)
        {
            owner = player;           
        }

        public override void MoveTo(Board board, Square newSquare)
        {
            hasMoved = true;
            base.MoveTo(board,newSquare);
        }
        

        public override IEnumerable<Square> GetAvailableMoves(Board board, Square currentSquare)
        {

            var squares = new List<Square>();
            
            

            if (this.owner == Player.White)
            {
                if (!hasMoved)
                {
                    squares.Add(new Square(currentSquare.Row - 2, currentSquare.Col));
                }

                squares.Add(new Square(currentSquare.Row - 1, currentSquare.Col));
            }
            else
            {
                if (!hasMoved)
                {
                    squares.Add(new Square(currentSquare.Row + 2, currentSquare.Col));
                }

                squares.Add(new Square(currentSquare.Row + 1, currentSquare.Col));

            }

            return squares;
        }
    }
}