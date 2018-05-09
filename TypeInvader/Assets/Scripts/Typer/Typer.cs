using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typer : MonoBehaviour
{

    private Transform target;
    [SerializeField]
    private float speed;
    private int playerLane;
    private int amountOfLanes;
    private Action stopGame;

    void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    public void MoveToX(float x)
    {
        target.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    internal void left(List<Lane> lanes)
    {
        if (playerLane > 0)
        {
            playerLane--;
        }
        MoveToX(lanes[playerLane].getSpawnPoint().x);
    }

    internal void right(List<Lane> lanes)
    {
        if (playerLane < amountOfLanes - 1)
        {
            playerLane++;
        }
        MoveToX(lanes[playerLane].getSpawnPoint().x);
    }

    internal void startOnRandomLane(int amountOfLanes, List<Lane> lanes)
    {
        target = new GameObject().transform;
        target.position = transform.position;
        this.amountOfLanes = amountOfLanes;
        playerLane = UnityEngine.Random.Range(0, amountOfLanes);
        Vector3 startLane = new Vector3(
            lanes[playerLane].getSpawnPoint().x,
            transform.position.y,
            transform.position.z
        );
        transform.position = startLane;
        target.position = startLane;
    }


    void OnTriggerEnter(Collider other)
    {
        if (stopGame != null)
        {
            stopGame();
        }
    }

    internal void registerGameStop(Action stopGame)
    {
        this.stopGame = stopGame;
    }

    internal Vector3 getPosition()
    {
        return transform.position;
    }
}
