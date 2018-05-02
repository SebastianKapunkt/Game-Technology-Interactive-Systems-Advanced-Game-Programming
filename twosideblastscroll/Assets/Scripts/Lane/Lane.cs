using System;
using System.Collections.Generic;
using UnityEngine;

internal class Lane
{
    private float startX;
    private float width;
    private float height;
    private Vector3 laneSpawnPoint;
    private Vector3 laneEndPoint;
    internal float Score { private set; get; }

    internal Lane(float startX, float height, float width)
    {
        this.startX = startX;
        this.height = height;
        this.width = width;

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

    internal string toString()
    {
        return String.Format(
            "startX: {0}, width: {1}, height: {2}",
            startX,
            width,
            height
        );
    }

    internal void subtractScore(float score)
    {
        if (score > 0)
        {
            Score = Score - score;
        }
    }

    internal void addScore(float score)
    {
        if (score > 0)
        {
            Score = Score + score;
        }
    }
}