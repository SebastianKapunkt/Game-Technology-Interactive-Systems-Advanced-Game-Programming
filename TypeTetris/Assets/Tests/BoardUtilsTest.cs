using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


public class BoardUtilsTest
{
    [Test]
    public void TestgetTopFilledRow()
    {
        int[,] stone = new int[,]{
            {0,0,0,0},
            {0,1,0,0},
            {0,1,0,0},
            {0,1,1,0}
        };

        Assert.AreEqual(1, BoardUtils.getMostTopFilledRowNumber(stone));

        stone = new int[,]{
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
            {1,1,1,1}
        };

        Assert.AreEqual(3, BoardUtils.getMostTopFilledRowNumber(stone));
    }

    [Test]
    public void TestBlockInRow()
    {
        int[,] stone = new int[,]{
            {0,0,0,0},
            {0,1,0,0},
            {0,1,0,0},
            {0,1,1,0}
        };

        Assert.AreEqual(false, BoardUtils.blockInRow(stone, 0));
        Assert.AreEqual(true, BoardUtils.blockInRow(stone, 1));
        Assert.AreEqual(true, BoardUtils.blockInRow(stone, 2));
        Assert.AreEqual(true, BoardUtils.blockInRow(stone, 3));
    }

    [Test]
    public void TestStoneBorder()
    {
        int left = 0;
        int right = 0;
        int[,] stone = new int[,]{
            {0,0,0,0},
            {0,1,0,0},
            {0,1,0,0},
            {0,1,1,0}
        };

        BoardUtils.getStoneBorders(stone, out left, out right);

        Assert.AreEqual(1, left);
        Assert.AreEqual(2, right);
    }

    [Test]
    public void TestCalculateSpaceToLeft()
    {
        int boardWidth = 5;
        int left = 1;
        int right = 2;

        Assert.AreEqual(1, BoardUtils.calculateSpaceToLeft(boardWidth, left, right));
    }
}