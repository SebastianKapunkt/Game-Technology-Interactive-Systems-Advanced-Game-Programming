using System;
using UnityEngine;

public class BoardUtils
{
    public static int getMostTopFilledRowNumber(int[,] stone)
    {
        int currentRow = 0;

        for (int r = 0; r < stone.GetLength(0); r++)
        {
            if (blockInRow(stone, r))
            {
                break;
            }
            currentRow++;
        }

        return currentRow;
    }

    public static bool blockInRow(int[,] row, int rowNumber)
    {
        for (int c = 0; c < row.GetLength(1); c++)
        {
            if (row[rowNumber, c] == 1)
            {
                return true;
            }
        }
        return false;
    }

    public static void getStoneBorders(int[,] stone, out int left, out int right)
    {
        int mostLeft = stone.GetLength(1);
        int mostRight = 0;

        for (int r = 0; r < stone.GetLength(0); r++)
        {
            for (int c = 0; c < stone.GetLength(1); c++)
            {
                if (stone[r, c] == 1)
                {
                    mostLeft = Math.Min(mostLeft, c);
                    mostRight = Math.Max(mostRight, c);
                }
            }
        }

        left = mostLeft;
        right = mostRight;
    }

    public static int calculateSpaceToLeft(int boardWith, int left, int right)
    {
        int stoneWidth = right - left + 1;
        if (boardWith - stoneWidth == 0)
        {
            return 0;
        }
        else
        {
            return (boardWith - stoneWidth) / 2;
        }
    }

    public static void print2DArray(int[,] grid)
    {
        string row = " ";
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
				row = row + " " + grid[i,j];
            }
            Debug.Log(row);
            row = "";
        }
        Debug.Log("#########################");
    }
}