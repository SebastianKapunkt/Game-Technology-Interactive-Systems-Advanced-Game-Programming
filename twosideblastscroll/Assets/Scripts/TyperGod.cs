using System.Collections.Generic;
using UnityEngine;

public class TyperGod : MonoBehaviour
{
    private List<Lane> lanes;
    private List<LaneWalker> existingWalker;

    public void Update(){
        foreach(Lane lane in lanes){
            lane.checkLane();
        }
    }

    public int getScore(){
        int score = 0;
        foreach(Lane lane in lanes){
            score = score + lane.Score;
        }        
        return score;
    }
}
