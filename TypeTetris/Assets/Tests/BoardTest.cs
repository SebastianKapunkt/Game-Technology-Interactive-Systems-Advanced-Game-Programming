using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BoardTest {

    [Test]
    public void DefaultBoardTest() {
        Board board = new Board(4,7);
        Assert.AreEqual(4, board.middleField);
    }

}
