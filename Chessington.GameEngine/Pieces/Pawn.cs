using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private Player owner;
        private bool hasMoved = false;
        private List<Square> squares;

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
            squares = new List<Square>();
            int forward = (base.Player == Player.White) ? -1 : 1;
            AddPawnForwardMovesToSquares(currentSquare, board, forward);
            AddPawnAttackMovesToSquares(currentSquare,board,forward);           
            return squares;
        }

        private void AddPawnForwardMovesToSquares(Square currentSquare, Board board, int forward)
        {
            var forwardSquare = new Square(currentSquare.Row + forward, currentSquare.Col);
            if (Board.IsSquareInBounds(forwardSquare) && !board.IsPieceOnSquare(forwardSquare))
            {
                squares.Add(forwardSquare);
                if (!hasMoved)
                {
                    var doubleForwardSquare = new Square(currentSquare.Row + 2 * forward, currentSquare.Col);
                    if (Board.IsSquareInBounds(doubleForwardSquare) && !board.IsPieceOnSquare(doubleForwardSquare))
                    {
                        squares.Add(doubleForwardSquare);
                    }
                }
            }
            
        }

        private void AddPawnAttackMovesToSquares(Square currentSquare, Board board, int forward)
        {
            
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
            
        }
    }
}