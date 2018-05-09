using UnityEngine;

public class ColorPoint
{
    private string mappedTo;
    private Vector4 position;
    private Vector4 colorMask;

    private Vector2 direction = new Vector2(0,1);

    private float minX = 0.1f;
    private float maxX = 0.9f;
    private float minY = 0.1f;
    private float maxY = 0.9f;

    private float moveByStep = 0.005f;

    public ColorPoint(string mappedTo, Vector4 position, Vector4 colorMask)
    {
        this.mappedTo = mappedTo;
        this.position = position;
        this.colorMask = colorMask;
    }

    public Vector4 nextPosition()
    {
        if(direction.x == 1){
            position.x = position.x + moveByStep;
        }else{
            position.x = position.x - moveByStep;
        }

        if(direction.y == 1){
            position.y = position.y + moveByStep;
        }else{
            position.y = position.y - moveByStep;
        }

        if (position.x > maxX)
        {
            direction.x = 0;
        }
        if (position.x < minX)
        {
            direction.x = 1;
        }
        if (position.y > maxY)
        {
            direction.y = 0;
        }
        if (position.y < minY)
        {
            direction.y = 1;
        }

        return position;
    }

    public Vector4 getColorMask()
    {
        return colorMask;
    }

    public string getMappingName()
    {
        return mappedTo;
    }

    public void randomDirection(){
        direction = new Vector2(Random.Range(0,2), Random.Range(0,2));
    }
}