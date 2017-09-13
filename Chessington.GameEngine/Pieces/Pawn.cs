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
            base.MoveTo(board, newSquare);
        }


        public override IEnumerable<Square> GetAvailableMoves(Board board, Square currentSquare)
        {

            var squares = new List<Square>();
            int forward = (base.Player == Player.White) ? -1 : 1;


            var forwardSquare = new Square(currentSquare.Row + forward, currentSquare.Col);
            if (Board.IsSquareInBounds(forwardSquare) && !board.IsPieceOnSquare(forwardSquare))
            {

                if (!hasMoved)
                {
                    var doubleForwardSquare = new Square(currentSquare.Row + 2 * forward, currentSquare.Col);

                    if (Board.IsSquareInBounds(doubleForwardSquare) && !board.IsPieceOnSquare(doubleForwardSquare))
                    {
                        squares.Add(doubleForwardSquare);
                    }
                }


                squares.Add(forwardSquare);
            }

            var diagonalSquare = new Square(currentSquare.Row + forward, currentSquare.Col - 1);
            if (Board.IsSquareInBounds(diagonalSquare))
            {
                if (board.IsPieceOnSquare(diagonalSquare))
                {
                    squares.Add(diagonalSquare);
                }
            }
            diagonalSquare = new Square(currentSquare.Row + forward, currentSquare.Col + 1);
            if (Board.IsSquareInBounds(diagonalSquare))
            {
                if (board.IsPieceOnSquare(diagonalSquare))
                {
                    squares.Add(diagonalSquare);
                }
            }





            squares.RemoveAll(s => !Board.IsSquareInBounds(s));
            squares.RemoveAll(s => board.IsPieceInBetweenVerticalExclusive(s.Col, s.Row, currentSquare.Row));



            return squares;
        }


    }
}