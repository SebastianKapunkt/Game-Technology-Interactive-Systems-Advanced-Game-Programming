using System.Collections.Generic;
using UnityEngine;

public class Lane
{
    private int startX;
    private int width;
    private int height;
    public int Score { private set; get;}

    private List<LaneWalker> laneItems;

    public Vector2 getSpawnPoint(){
        return new Vector2(startX + width/2, 0);
    }

    public void checkLane(){
        foreach(LaneWalker item in laneItems){
            if(item.getYPosition() > height){
                Score = Score - item.Score;
                item.destroy();
            }
        }
    }

    public void RemoveDestroyedItem(LaneWalker item){
        Score = Score + item.Score;
        laneItems.Remove(item);
    }
}