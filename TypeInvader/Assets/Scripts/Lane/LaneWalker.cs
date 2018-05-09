using System;
using UnityEngine;
using UnityEngine.UI;

internal class LaneWalker : MonoBehaviour
{
    private float speed;
    private GameObject target;
    internal string keyWord { private set; get; }
    internal float Score { private set; get; }
    private Action<float> changeScoreCallback;
    private Action<LaneWalker> removeWalker;
    [SerializeField]
    private Text wordToType;
    private bool isMoving = true;

    internal void initilize(
        Lane lane,
        float speed,
        float score,
        string keyWord,
        Action<float> changeScoreCallback,
        Action<LaneWalker> removeWalker
    )
    {
        this.removeWalker = removeWalker;
        this.speed = speed;
        this.keyWord = keyWord;
        this.changeScoreCallback = changeScoreCallback;
        Score = score;

        // set position to move in lave
        target = new GameObject();
        target.transform.position = lane.getLaneEndPoint();

        // set spawn position in lane
        transform.position = lane.getSpawnPoint();
        wordToType.text = keyWord;
    }

    internal Vector3 getPosition()
    {
        return transform.position;
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
            removeWalker(this);
            changeScoreCallback(-Score);
            cleanUp();
        }
    }

    internal void kill()
    {
        changeScoreCallback(Score);
        cleanUp();
    }

    internal void cleanUp()
    {
        isMoving = false;
        Destroy(target);
        target = null;
        Destroy(gameObject, 0.3f);
    }
}