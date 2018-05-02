using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

	private Transform target;
	[SerializeField]
    private float speed;

	void Start(){
		target = new GameObject().transform;
		target.position = transform.position;
	}

    void Update() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

	public void MoveToX(int x){
		target.position = new Vector3(x, transform.position.y, transform.position.z);
	}
}
