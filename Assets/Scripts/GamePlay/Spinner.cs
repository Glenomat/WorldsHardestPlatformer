using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public GameObject spinnerComp;
    private List<GameObject> spinners = new List<GameObject>();
    private SpriteRenderer spinnerRenderer;

    public int spinnCount = 4;
    public float distance = 1f;
    private float rotation = 0f;
    public float speed = 0.05f;
    private float spinnerRotation;

    void Start()
    {
        spinnerRenderer = GetComponent<SpriteRenderer>();
        for(int i = 0; i < spinnCount; i++)
        {
            //Spawns Spinner Components and sets them in a circle around center point
            spinners.Add(Instantiate<GameObject>(spinnerComp, transform));
            transform.rotation = Quaternion.Euler(0, 0, rotation);
            spinners[i].transform.position = new Vector2(transform.position.x - distance, transform.position.y);
            rotation += (360f / spinnCount);
            if(spinnerRenderer)
                spinners[i].GetComponent<SpriteRenderer>().material = spinnerRenderer.material;
        }
        //Resets Center points rotation
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void Update()
    {
        //When Paused no movement
        if (Time.timeScale == 0) return;
        //Rotates the Spinner in set Speed
        transform.rotation = Quaternion.Euler(0, 0, spinnerRotation);
        spinnerRotation += speed;
    }
}
    