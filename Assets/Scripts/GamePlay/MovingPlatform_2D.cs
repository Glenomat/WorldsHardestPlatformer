using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform_2D : MonoBehaviour
{
    private List<Vector2> movePoints = new List<Vector2>();

    public bool useStartPos = true;
    public float speed = 5.0f;
    public float movePointRadius = 0.5f;
    private int curr = 0;

    void Start()
    {
        //Checks if platform should use its Starting point and adds location to Array
        if(useStartPos)
            movePoints.Add(transform.position);
        //Checks the Children in Platform and adds all locations to the array
        for(int i = 0; i < transform.childCount; i++)
        {
            movePoints.Add(transform.GetChild(i).transform.position);

            //Changes the starting point in array based on the X-Position of moveing locations
            if (movePoints[i].x < transform.position.x)
                curr = i + 1;
        }
        if (curr >= movePoints.Count)
            curr = 0;
    }

    void Update()
    {
        //Moves platform towards movingpoints and updates position in array when close enough
        if(Vector2.Distance(movePoints[curr], transform.position) < movePointRadius)
        {
            curr++;
            if (curr >= movePoints.Count)
                curr = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, movePoints[curr], Time.deltaTime * speed);
    }
}
