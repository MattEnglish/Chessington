using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chessington.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessington.GameEngine.Tests
{
    [TestClass()]
    public class BoardTests
    {
        [TestMethod()]
        public void IsPieceInBetweenForwardDiagonalExclusiveTest()
        {
            Board board = new Board();
            var startingSquare = new Square(5,7);
            var endingSquare = new Square(2,4);

            Assert.IsFalse(board.IsPieceInBetweenForwardDiagonalExclusive(startingSquare,endingSquare));
            board.AddPiece(new Square(3,5),new Pieces.Pawn(Player.Black));
            Assert.IsTrue(board.IsPieceInBetweenForwardDiagonalExclusive(startingSquare, endingSquare));
        }
    }
}

namespace Chessington.GameEngineTests
{
    class BoardTests
    {
    }
}
