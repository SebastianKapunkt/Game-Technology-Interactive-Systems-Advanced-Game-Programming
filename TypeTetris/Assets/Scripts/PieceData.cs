/*
 * Arthur Cousseau, 2017
 * https://www.linkedin.com/in/arthurcousseau/
 * Please share this if you enjoy it! :)
*/

using UnityEngine;

[CreateAssetMenu(fileName = "Piece_Data", menuName = "Piece")]
public class PieceData : ScriptableObject
{
    private const int defaultGridSize = 4;

    [Range(1, 5)]
    public int gridSize = defaultGridSize;

    public CellRow[] cells = new CellRow[defaultGridSize];


    public bool[,] GetCells()
    {
        bool[,] ret = new bool[gridSize, gridSize];

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                ret[i, j] = cells[i].row[j];
            }
        }

        return ret;
    }

    public int[,] getAsIntArray()
    {
        int[,] intGrid = new int[gridSize, gridSize];

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                intGrid[i, j] = cells[i].row[j] ? 1 : 0;
            }
        }

        return intGrid;
    }


    [System.Serializable]
    public class CellRow
    {
        public bool[] row = new bool[defaultGridSize];
    }
}
