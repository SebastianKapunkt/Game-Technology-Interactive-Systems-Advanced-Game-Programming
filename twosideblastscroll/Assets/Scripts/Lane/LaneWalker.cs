using System;
using UnityEngine;

public class LaneWalker : MonoBehaviour
{
    private Lane lane;

    public int Score { private set; get;}

    public LaneWalker(Lane lane, int score){
        this.lane = lane;
        this.Score = score;
    }

    internal float getYPosition()
    {
        return transform.position.y;
    }

    internal void destroy()
    {
        Destroy(gameObject);
    }

    internal void kill(){
        lane.RemoveDestroyedItem(this);
        destroy();
    }
}