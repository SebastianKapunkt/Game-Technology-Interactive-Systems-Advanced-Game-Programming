using System.Collections.Generic;
using UnityEngine;

internal class TyperGod : MonoBehaviour
{
    private List<Lane> lanes;
    private List<LaneWalker> existingWalker;
    [SerializeField]
    private LaneWalker astroid;
    [SerializeField]
    private float score;
    [SerializeField]
    private int amountOfLanes;
    [SerializeField]
    private Typer typer;

    internal void Start(){
        Vector3 stageBottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        Vector3 stageTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        lanes = LaneFactory.GenerateLanes(
            new Vector2(stageTopLeft.x, stageTopLeft.z),
            new Vector2(stageBottomRight.x, stageBottomRight.z),
            amountOfLanes
        );

        existingWalker = new List<LaneWalker>();
        existingWalker.Add(Instantiate(astroid));
        existingWalker[0].initilize(lanes[2], 2, 100, "hey", this);

        typer.startOnRandomLane(amountOfLanes, lanes);
    }

    internal void moveTyperLaneLeft()
    {
        typer.left(lanes);
    }

    internal void moveTyperLaneRight()
    {
        typer.right(lanes);
    }

    internal void Update(){
        score = getScore();
    }

    internal float getScore(){
        float score = 0;
        foreach(Lane lane in lanes){
            score = score + lane.Score;
        }        
        return score;
    }

    internal void destroyObjectWithKeyWord(string keyword){
        List<LaneWalker> walkerToDestroy = new List<LaneWalker>();
        foreach(LaneWalker walker in existingWalker){
            if(walker.keyWord.Equals(keyword)){
                walkerToDestroy.Add(walker);
            }
        }
        foreach(LaneWalker walker in walkerToDestroy){
            existingWalker.Remove(walker);
            walker.kill();
        }
    }

    internal void killMe(LaneWalker walker)
    {
        existingWalker.Remove(walker);
    }
}
