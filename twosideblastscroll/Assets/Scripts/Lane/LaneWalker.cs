using System;
using UnityEngine;
using UnityEngine.UI;

internal class LaneWalker : MonoBehaviour
{
    private float speed;
    private GameObject target;
    internal string keyWord { private set; get; }
    internal float Score { private set; get; }
    private Action<LaneWalker> killCallback;
    private Action<float> changeScoreCallback;
    [SerializeField]
    private Text wordToType;
    private bool isMoving = true;

    internal void initilize(
        Lane lane,
        float speed,
        float score,
        string keyWord,
        Action<LaneWalker> killCallback,
        Action<float> changeScoreCallback
    )
    {
        this.speed = speed;
        this.keyWord = keyWord;
        this.killCallback = killCallback;
        this.changeScoreCallback = changeScoreCallback;
        Score = score;

        // set position to move in lave
        target = new GameObject();
        target.transform.position = lane.getLaneEndPoint();

        // set spawn position in lane
        transform.position = lane.getSpawnPoint();
        wordToType.text = keyWord;
    }

    internal void pause()
    {
        isMoving = false;
    }

    internal void continueWalking()
    {
        isMoving = true;
    }

    internal void Update()
    {
        if (isMoving)
        {
            moveToTarget();
            checkForTargetReached();
        }
    }

    private void moveToTarget()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.transform.position,
                step
            );
        }
    }

    internal void checkForTargetReached()
    {
        if (transform.position.z < (target.transform.position.z + 0.5f))
        {
            changeScoreCallback(-Score);
            cleanUp();
        }
    }

    internal void kill()
    {
        killCallback(this);
        changeScoreCallback(Score);
        cleanUp();
    }

    internal void cleanUp()
    {
        Destroy(target);
        Destroy(gameObject);
    }
}