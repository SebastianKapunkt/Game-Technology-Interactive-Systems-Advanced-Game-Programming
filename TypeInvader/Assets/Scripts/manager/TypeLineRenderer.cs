using System;
using UnityEngine;

public class TypeLineRenderer : MonoBehaviour{
    
    [SerializeField]
    private float timeToLife;
    private float spawned;
    private Action<TypeLineRenderer> removeLine;

    internal void initilize(Vector3 start, Vector3 end, Action<TypeLineRenderer> removeLine){
        this.removeLine = removeLine;
        GetComponent<LineRenderer>().useWorldSpace = true;
        GetComponent<LineRenderer>().positionCount = 2;
        GetComponent<LineRenderer>().SetPosition(0, start);
        GetComponent<LineRenderer>().SetPosition(1, end);
        Destroy (gameObject, timeToLife);
    }

    public void OnDestroy(){
        removeLine(this);
    }
}