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
        BoardUtils.print2DArray(grid);
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
