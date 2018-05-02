using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderMover : MonoBehaviour
{

    Material shaderMaterial;
    [SerializeField]
    private Vector2 point1;
    [SerializeField]
    private Vector2 point2;
    [SerializeField]
    private Vector2 point3;
	[SerializeField]
    private Vector3 mask1;
    [SerializeField]
    private Vector3 mask2;
    [SerializeField]
    private Vector3 mask3;
	[SerializeField]
	private float refreshRate = 0.01f;
	[SerializeField]
	private float direction_factor = 50;
    private List<ColorPoint> points;

    void Start()
    {
        points = new List<ColorPoint>();
        points.Add(new ColorPoint("_PointOnePosition", point1, mask1));
        points.Add(new ColorPoint("_PointTwoPosition", point2, mask2));
        points.Add(new ColorPoint("_PointThreePosition", point3, mask3));

        shaderMaterial = GetComponent<Renderer>().material;
        shaderMaterial.SetVector("_PointOneMask", points[0].getColorMask());
        shaderMaterial.SetVector("_PointTwoMask", points[1].getColorMask());
        shaderMaterial.SetVector("_PointThreeMask", points[2].getColorMask());
        InvokeRepeating("MoveShaderPoints", 0.5f, refreshRate);
		InvokeRepeating("RandomDirections", 0.5f, refreshRate * direction_factor);
    }

    void MoveShaderPoints()
    {
        foreach (ColorPoint point in points)
        {
            shaderMaterial.SetVector(point.getMappingName(), point.nextPosition());
        }
    }

	void RandomDirections(){
		foreach (ColorPoint point in points)
        {
            point.randomDirection();
        }
	}
}
