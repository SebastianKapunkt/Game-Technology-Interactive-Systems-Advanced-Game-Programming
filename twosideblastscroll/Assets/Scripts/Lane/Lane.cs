using System;
using System.Collections.Generic;
using UnityEngine;

internal class Lane
{
    private Vector3 laneSpawnPoint;
    private Vector3 laneEndPoint;

    internal Lane(float startX, float height, float width)
    {
        laneEndPoint = new Vector3(startX + width / 2, 0, -2);
        laneSpawnPoint = new Vector3(startX + width / 2, 0, height + 1);
    }

    internal Vector3 getLaneEndPoint()
    {
        return laneEndPoint;
    }

    internal Vector3 getSpawnPoint()
    {
        return laneSpawnPoint;
    }
}