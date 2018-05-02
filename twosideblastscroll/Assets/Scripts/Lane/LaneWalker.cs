using System;
using UnityEngine;

internal class LaneWalker : MonoBehaviour
{
    private Lane lane;
    private float speed;
    private Transform target;
    internal string keyWord {private set; get;}
    internal float Score { private set; get;}
    private TyperGod god;

    internal void initilize(
        Lane lane, 
        float speed, 
        float score, 
        string keyWord,
        TyperGod god
    ){
        this.lane = lane;
        this.speed = speed;
        this.keyWord = keyWord;
        this.god = god;
        Score = score;

        // set position to move in lave
        target = new GameObject().transform;
        target.position = lane.getLaneEndPoint();

        // set spawn position in lane
        transform.position = lane.getSpawnPoint();
    }

    internal void Update(){
        moveToTarget();
        checkForTargetReached();
    }

    private void moveToTarget(){
        if(target != null){
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    internal void checkForTargetReached(){
        if(transform.position.z < (target.position.z + 0.5f)){
            lane.subtractScore(Score);
            Destroy(gameObject);
        }
    }

    internal void kill(){
        god.killMe(this);
        lane.addScore(Score);
        Destroy(gameObject);
    }
}