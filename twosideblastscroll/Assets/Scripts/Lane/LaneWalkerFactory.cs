using System;
using System.Collections.Generic;
using UnityEngine;

public class LaneWalkerFactory : MonoBehaviour
{
    internal static LaneWalker spawn(
        LaneWalker newWalker,
        List<Lane> lanes,
        float gameSpeed,
        Action<LaneWalker> killMe,
        Action<float> changeScore,
        string[] wordsToPick
        )
    {
        int randomLane = UnityEngine.Random.Range(0, lanes.Count);
        string keyword = wordsToPick[UnityEngine.Random.Range(0, wordsToPick.Length)];

        newWalker.initilize(
            lanes[randomLane],
            gameSpeed,
            keyword.Length * 10,
            keyword,
            killMe,
            changeScore
        );

        return newWalker;
    }
}