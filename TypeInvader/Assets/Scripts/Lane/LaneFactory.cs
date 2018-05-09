using System.Collections.Generic;
using UnityEngine;

public class LaneFactory
{
    internal static List<Lane> GenerateLanes(
        Vector2 areaTopLeft,
        Vector2 areaBottomRight,
        float numberOfLanes
    ){
        List<Lane> lanes = new List<Lane>();
        float startX = areaTopLeft.x;

        float width = Mathf.Abs(areaBottomRight.x - areaTopLeft.x);
        float height = Mathf.Abs(areaBottomRight.y - areaTopLeft.y);

        float laneWidth = width / numberOfLanes;

        for(int i = 0; i < numberOfLanes; i++){
            lanes.Add(new Lane(startX, height, laneWidth));
            startX = startX + laneWidth;
        }

        return lanes;
    }
}