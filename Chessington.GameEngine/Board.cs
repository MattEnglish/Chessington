﻿using System;
using System.Collections.Generic;
using System.Linq;
using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine
{
    public class Board
    {
        private readonly Piece[,] board;
        public Player CurrentPlayer { get; private set; }
        public IList<Piece> CapturedPieces { get; private set; } 

        public Board()
            : this(Player.White) { }

        public Board(Player currentPlayer, Piece[,] boardState = null)
        {
            board = boardState ?? new Piece[GameSettings.BoardSize, GameSettings.BoardSize]; 
            CurrentPlayer = currentPlayer;
            CapturedPieces = new List<Piece>();
        }

        public static bool IsSquareInBounds(Square square)
        {
            if (square.Row < GameSettings.BoardSize && square.Col < GameSettings.BoardSize && square.Row >= 0 && square.Col >= 0)
            {
                return true;
            }
            return false;
        }

        public void AddPiece(Square square, Piece pawn)
        {
            board[square.Row, square.Col] = pawn;
        }
    
        public Piece GetPiece(Square square)
        {
            return board[square.Row, square.Col];
        }
        
        public Square FindPiece(Piece piece)
        {
            for (var row = 0; row < GameSettings.BoardSize; row++)
                for (var col = 0; col < GameSettings.BoardSize; col++)
                    if (board[row, col] == piece)
                        return Square.At(row, col);

            throw new ArgumentException("The supplied piece is not on the board.", "piece");
        }

        public void MovePiece(Square from, Square to)
        {
            var movingPiece = board[from.Row, from.Col];
            if (movingPiece == null) { return; }

            if (movingPiece.Player != CurrentPlayer)
            {
                throw new ArgumentException("The supplied piece does not belong to the current player.");
            }

            //If the space we're moving to is occupied, we need to mark it as captured.
            if (board[to.Row, to.Col] != null)
            {
                OnPieceCaptured(board[to.Row, to.Col]);
            }

            //Move the piece and set the 'from' square to be empty.
            board[to.Row, to.Col] = board[from.Row, from.Col];
            board[from.Row, from.Col] = null;

            CurrentPlayer = movingPiece.Player == Player.White ? Player.Black : Player.White;
            OnCurrentPlayerChanged(CurrentPlayer);
        }
        
        public delegate void PieceCapturedEventHandler(Piece piece);
        
        public event PieceCapturedEventHandler PieceCaptured;

        protected virtual void OnPieceCaptured(Piece piece)
        {
            var handler = PieceCaptured;
            if (handler != null) handler(piece);
        }

        public delegate void CurrentPlayerChangedEventHandler(Player player);

        public event CurrentPlayerChangedEventHandler CurrentPlayerChanged;

        protected virtual void OnCurrentPlayerChanged(Player player)
        {
            var handler = CurrentPlayerChanged;
            if (handler != null) handler(player);
        }

        public bool IsPieceOnSquare(Square square)
        {
            if (board[square.Row,square.Col] == null)
            {
                return false;
            }
            return true;
        }

        public bool isPieceDirectlyBetweenHorizontalOrVerticalExclusive(Square startingSquare, Square targetSquare)
        {
            if (startingSquare.Row == targetSquare.Row)
            {
                if (IsPieceInBetweenHorizontalExclusive(startingSquare.Row, startingSquare.Col, targetSquare.Col))
                {
                    return true;
                }
            }
            if (startingSquare.Col == targetSquare.Col)
            {
                if (IsPieceInBetweenVerticalExclusive(startingSquare.Col, startingSquare.Row, targetSquare.Row))
                {
                    return true;
                }
            }
            return false;
        }


        public bool IsPieceInBetweenHorizontalExclusive(int row, int startingCol, int targetCol)
        {
            for (int col = Math.Min(startingCol, targetCol) + 1; col < Math.Max(startingCol, targetCol); col++)
            {
                if (IsPieceOnSquare(new Square(row, col)))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsPieceInBetweenVerticalExclusive(int col, int startingRow, int targetRow)
        {
           
            
                for (int row = Math.Min(startingRow,targetRow)+1;  row < Math.Max(startingRow,targetRow); row++)
                {
                    if (IsPieceOnSquare(new Square(row, col)))
                    {
                        return true;
                    }
                }
            
            
            return false;
        }

    }
}
