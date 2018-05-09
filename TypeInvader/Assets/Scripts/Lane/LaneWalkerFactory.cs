using System;
using System.Collections.Generic;
using UnityEngine;

public class LaneWalkerFactory : MonoBehaviour
{
    internal static LaneWalker spawn(
        LaneWalker newWalker,
        List<Lane> lanes,
        float gameSpeed,
        Action<float> changeScore,
        string[] wordsToPick,
        Action<LaneWalker> removeWalker
        )
    {
        int randomLane = UnityEngine.Random.Range(0, lanes.Count);
        string keyword = wordsToPick[UnityEngine.Random.Range(0, wordsToPick.Length)];

        newWalker.initilize(
            lanes[randomLane],
            gameSpeed,
            keyword.Length * 10,
            keyword,
            changeScore,
            removeWalker
        );

        return newWalker;
    }
}