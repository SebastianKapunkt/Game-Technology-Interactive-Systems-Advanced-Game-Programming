using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField]
    private int[,] shape = new int[4, 4];
    [SerializeField]
    private PieceData data;

    // Use this for initialization
    void Start()
    {
        int[,] grid = getBlockData();
        string row = "";
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
				row = row + " " + grid[i,j];
            }
            Debug.Log(row);
            row = "";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int[,] getBlockData()
    {
        return data.getAsIntArray();
    }
}
