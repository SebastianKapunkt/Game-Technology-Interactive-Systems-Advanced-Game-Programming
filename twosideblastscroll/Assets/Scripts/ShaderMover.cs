using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderMover : MonoBehaviour {

	Material shaderMaterial;

	// Use this for initialization
	void Start () {
		shaderMaterial = GetComponent<Renderer>().material;
		InvokeRepeating("MoveShaderPoints", 0.5f, 0.1f);
	}
	
	// Update is called once per frame
	void MoveShaderPoints(){
		shaderMaterial.SetVector("_PointOnePosition", new Vector3(rnd(),rnd(), 0));
		shaderMaterial.SetVector("_PointTwoPosition", new Vector3(rnd(), rnd(), 0));
		shaderMaterial.SetVector("_PointThreePosition", new Vector3(rnd(), rnd(), 0));
	}

	float rnd(){
		return Random.Range(0.0f, 1.0f);
	}
}
