using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {

        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            return GetAvailableMoves(board, currentSquare);
        }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board, Square currentSquare);

        public virtual void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        protected IEnumerable<Square> HorizontalSquares(Square currentSquare)
        {
            for (int row = 0; row < 8; row++)
            {
                if (row != currentSquare.Row)
                {
                    yield return (new Square(row, currentSquare.Col));
                }
            }
        }

        protected IEnumerable<Square> VerticalSquares(Square currentSquare)
        {
            for (int col = 0; col < 8; col++)
            {
                if (col != currentSquare.Row)
                {
                    yield return (new Square(currentSquare.Row, col));
                }
            }
        }
    }
}