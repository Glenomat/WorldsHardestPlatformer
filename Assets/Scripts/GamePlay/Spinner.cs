using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public GameObject spinnerComp;
    private List<GameObject> spinners = new List<GameObject>();

    public int spinnCount = 4;
    public float distance = 1f;
    private float rotation = 0f;
    public float speed = 0.05f;
    private float spinnerRotation;

    void Start()
    {
        for(int i = 0; i < spinnCount; i++)
        {
            spinners.Add(Instantiate<GameObject>(spinnerComp, transform));
            transform.rotation = Quaternion.Euler(0, 0, rotation);
            spinners[i].transform.position = new Vector2(transform.position.x - distance, transform.position.y);
            rotation += (360f / spinnCount); 
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void Update()
    {
        if (Time.timeScale == 0) return;
        transform.rotation = Quaternion.Euler(0, 0, spinnerRotation);
        spinnerRotation += speed;
    }
}
    