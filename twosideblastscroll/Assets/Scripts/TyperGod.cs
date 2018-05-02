using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal class TyperGod : MonoBehaviour
{
    private List<Lane> lanes;
    private List<LaneWalker> existingWalker;
    private float nextSpawn = 0;

    [SerializeField]
    private LaneWalker astroid;
    [SerializeField]
    private float score = 0;
    [SerializeField]
    private int amountOfLanes;
    [SerializeField]
    private Typer typer;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private float gameSpeed; 
    [SerializeField]
    private float spawnRate; 

    void Start()
    {
        Vector3 stageBottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 stageTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        lanes = LaneFactory.GenerateLanes(
            new Vector2(stageTopLeft.x, stageTopLeft.z),
            new Vector2(stageBottomRight.x, stageBottomRight.z),
            amountOfLanes
        );
        existingWalker = new List<LaneWalker>();
        typer.startOnRandomLane(amountOfLanes, lanes);
    }

    void FixedUpdate(){
        if(Time.time > nextSpawn){
            spawnLaneWalker();
            nextSpawn = Time.time + spawnRate;
        }
    }

    internal void spawnLaneWalker(){
        LaneWalker newWalker = Instantiate(astroid);
        newWalker = LaneWalkerFactory.spawn(
            newWalker,
            lanes,
            gameSpeed,
            killMe,
            changeScore
        );
        existingWalker.Add(newWalker);
    }

    internal void moveTyperLaneLeft()
    {
        typer.left(lanes);
    }

    internal void moveTyperLaneRight()
    {
        typer.right(lanes);
    }

    internal void destroyObjectWithKeyWord(string keyword)
    {
        List<LaneWalker> walkerToDestroy = new List<LaneWalker>();
        foreach (LaneWalker walker in existingWalker)
        {
            if (walker.keyWord.Equals(keyword))
            {
                walkerToDestroy.Add(walker);
            }
        }
        foreach (LaneWalker walker in walkerToDestroy)
        {
            existingWalker.Remove(walker);
            walker.kill();
        }
    }

    internal void killMe(LaneWalker walker)
    {
        existingWalker.Remove(walker);
    }

    private void changeScore(float score)
    {
        this.score = this.score + score;
        scoreText.text = "Score: " + this.score;
    }
}
