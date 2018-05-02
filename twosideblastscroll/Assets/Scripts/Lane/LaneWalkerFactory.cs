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
        Action<float> changeScore
        )
    {
        int randomLane = UnityEngine.Random.Range(0, lanes.Count);
        Debug.Log(randomLane);
        Debug.Log("count: " + lanes.Count);
        newWalker.initilize(
            lanes[randomLane],
            gameSpeed,
            100,
            "hey",
            killMe,
            changeScore
        );

        return newWalker;
    }
}