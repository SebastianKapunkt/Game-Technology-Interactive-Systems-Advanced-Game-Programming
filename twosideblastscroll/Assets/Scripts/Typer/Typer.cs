using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typer : MonoBehaviour
{

    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int playerLane;
    private int amountOfLanes;

    void Start()
    {
        target = new GameObject().transform;
        target.position = transform.position;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
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
}
