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
        if(useStartPos)
            movePoints.Add(transform.position);

        for(int i = 0; i < transform.childCount; i++)
        {
            movePoints.Add(transform.GetChild(i).transform.position);

            if (movePoints[i].x < transform.position.x)
                curr = i + 1;
        }
        if (curr >= movePoints.Count)
            curr = 0;
        Debug.Log(curr);
    }

    void Update()
    {
        if(Vector2.Distance(movePoints[curr], transform.position) < movePointRadius)
        {
            curr++;
            if (curr >= movePoints.Count)
                curr = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, movePoints[curr], Time.deltaTime * speed);
    }
}
