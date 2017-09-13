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
            var availableSquares = (List<Square>)GetAvailableMoves(board, currentSquare);
            availableSquares.RemoveAll(s => board.isFriendlyPieceOnSquare(Player,s));
            return availableSquares;
        }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board, Square currentSquare);

        public virtual void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        protected IEnumerable<Square> GetSquaresInRow(Square currentSquare)
        {
            for (int row = 0; row < 8; row++)
            {
                if (row != currentSquare.Row)
                {
                    yield return (new Square(row, currentSquare.Col));
                }
            }
        }

        protected IEnumerable<Square> GetSquaresInCol(Square currentSquare)
        {
            for (int col = 0; col < 8; col++)
            {
                if (col != currentSquare.Row)
                {
                    yield return (new Square(currentSquare.Row, col));
                }
            }
        }

        protected IEnumerable<Square> GetSquaresInDiagonal(Square currentSquare)
        {
            var validSquares = new List<Square> ();
            validSquares.AddRange(GetInvalidSquaresWithin16BackDiagonal(currentSquare));
            validSquares.AddRange(GetInvalidSquaresWithin16ForwardDiagonal(currentSquare));
            validSquares.RemoveAll(s => !Board.IsSquareInBounds(s));
            return validSquares;
        }

        private IEnumerable<Square> GetInvalidSquaresWithin16ForwardDiagonal(Square currentSquare)
        {
            for (var i = -7; i < 8; i++)
            {
                yield return (new Square(currentSquare.Row + i, currentSquare.Col + i));
            }
        }

        private IEnumerable<Square> GetInvalidSquaresWithin16BackDiagonal(Square currentSquare)
        {
            for (var i = -7; i < 8; i++)
            {
                yield return (new Square(currentSquare.Row + i, currentSquare.Col - i));
            }
        }
    }
}