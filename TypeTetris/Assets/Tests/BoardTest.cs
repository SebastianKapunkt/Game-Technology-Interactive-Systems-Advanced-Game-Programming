using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BoardTest
{

    [Test]
    public void DefaultBoardTest()
    {
        Board board = new Board(3, 4);

        int[,] refArray = new int[,]{
            {0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0}
        };

        Assert.AreEqual(3, board.middleField);
        Assert.AreEqual(5, board.columns);
        Assert.AreEqual(3, board.rows);
        Assert.AreEqual(refArray, board.field);
    }

    [Test]
    public void TestInserBlock()
    {
        Board board = new Board(5, 7);

        int[,] stone = new int[,]{
            {0,0,0,0,0,0},
            {0,0,0,0,0,1},
            {0,0,0,0,0,1},
            {0,0,1,1,1,1}
        };

        BoardUtils.print2DArray(board.field);
        board.insertBlock(stone);

        int[,] expectedField = new int[,]{
            {0,0,0,0,1,0,0},
            {0,0,0,0,1,0,0},
            {0,1,1,1,1,0,0},
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0}
        };

        BoardUtils.print2DArray(board.field);
        Assert.AreEqual(expectedField, board.field);

        stone = new int[,]{
            {0,0,0,0,0,0},
            {0,0,1,1,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        };

        board.insertBlock(stone);

        expectedField = new int[,]{
            {0,0,2,2,1,0,0},
            {0,0,0,0,1,0,0},
            {0,1,1,1,1,0,0},
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0}
        };

        BoardUtils.print2DArray(board.field);
        Assert.AreEqual(expectedField, board.field);
    }

    [Test]
    public void TestTick(){
        Board board = new Board(5, 7);

        int[,] stone = new int[,]{
            {0,0,0,0,0,0},
            {0,0,0,0,0,1},
            {0,0,0,0,0,1},
            {0,0,1,1,1,1}
        };

        board.insertBlock(stone);
        BoardUtils.print2DArray(board.field);

        board.tick();
        BoardUtils.print2DArray(board.field);

        int[,] expectedField = new int[,]{
            {0,0,0,0,0,0,0},
            {0,0,0,0,1,0,0},
            {0,0,0,0,1,0,0},
            {0,1,1,1,1,0,0},
            {0,0,0,0,0,0,0}
        };

        Assert.AreEqual(expectedField, board.field);

        stone = new int[,]{
            {0,0,0,0,0,0},
            {0,0,1,1,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        };

        board.insertBlock(stone);
        BoardUtils.print2DArray(board.field);
        board.tick();
        BoardUtils.print2DArray(board.field);

        expectedField = new int[,]{
            {0,0,0,0,0,0,0},
            {0,0,2,2,1,0,0},
            {0,0,0,0,1,0,0},
            {0,1,1,1,1,0,0},
            {0,0,0,0,0,0,0},
        };

        Assert.AreEqual(expectedField, board.field);
    }

    [Test]
    public void TestCanCurrentGoDown(){
        Board board = new Board(5, 5);

        int[,] stone = new int[,]{
            {0,1,0},
            {1,1,1}
        };

        board.insertBlock(stone);
        board.tick();
        board.tick();
        Assert.AreEqual(true, board.canCurrentGoDown());
        BoardUtils.print2DArray(board.field);

        board.tick();
        Assert.AreEqual(false, board.canCurrentGoDown());
        BoardUtils.print2DArray(board.field);

        board.insertBlock(stone);
        Assert.AreEqual(true, board.canCurrentGoDown());
        BoardUtils.print2DArray(board.field);
        board.tick();
        Assert.AreEqual(false, board.canCurrentGoDown());
        BoardUtils.print2DArray(board.field);
    }
}
