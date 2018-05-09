using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TyperGod : MonoBehaviour
{
    private List<Lane> lanes;
    private List<LaneWalker> existingWalker;
    private float nextSpawn = 0;
    private string[] wordsToPick;

    [SerializeField]
    private LaneWalker laneWalker;
    [SerializeField]
    private Typer typer;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private PanelControl panelControl;
    [SerializeField]
    private GameStates state;
    [SerializeField]
    private float score = 0;
    [SerializeField]
    private int amountOfLanes;
    [SerializeField]
    private float gameSpeed;
    [SerializeField]
    private float calculatedSpeed;
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private float calculatedSpawnRate;

    internal void startGame()
    {
        state = GameStates.Playing;
        if (existingWalker != null)
        {
            foreach (LaneWalker walker in existingWalker)
            {
                walker.cleanUp();
            }
        }
        Vector3 stageBottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 stageTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        lanes = LaneFactory.GenerateLanes(
            new Vector2(stageTopLeft.x, stageTopLeft.z),
            new Vector2(stageBottomRight.x, stageBottomRight.z),
            amountOfLanes
        );
        score = 0;
        changeScore(score);
        existingWalker = new List<LaneWalker>();
        typer.startOnRandomLane(amountOfLanes, lanes);
        typer.registerGameStop(stopGame);
    }

    internal void pauseGame()
    {
        state = GameStates.Pause;
        foreach (LaneWalker walker in existingWalker)
        {
            walker.pause();
        }
    }

    internal void stopGame()
    {
        state = GameStates.Stop;
        foreach (LaneWalker walker in existingWalker)
        {
            walker.cleanUp();
        }
        existingWalker = new List<LaneWalker>();

        panelControl.showGameOver();
    }

    internal void continueGame()
    {
        state = GameStates.Playing;
        if (existingWalker != null)
        {
            foreach (LaneWalker walker in existingWalker)
            {
                walker.continueWalking();
            }
        }
    }

    internal GameStates getState()
    {
        return state;
    }

    void Start()
    {
        wordsToPick = SaveLoad.Load();
        state = GameStates.Stop;
    }

    void FixedUpdate()
    {
        if (state.Equals(GameStates.Playing) && Time.time > nextSpawn)
        {
            spawnLaneWalker();
            nextSpawn = Time.time + calculatedSpawnRate;
        }
    }

    internal void spawnLaneWalker()
    {
        calculatedSpeed = gameSpeed + score / 1000;
        calculatedSpawnRate = spawnRate - calculatedSpeed / 10;
        if (calculatedSpeed < gameSpeed)
        {
            calculatedSpeed = 1;
        }
        LaneWalker newWalker = Instantiate(laneWalker);
        newWalker = LaneWalkerFactory.spawn(
            newWalker,
            lanes,
            calculatedSpeed,
            changeScore,
            wordsToPick
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
            walker.kill();
            existingWalker.Remove(walker);
        }
    }

    private void changeScore(float score)
    {
        this.score = this.score + score;
        scoreText.text = "Score: " + this.score;
    }
}
