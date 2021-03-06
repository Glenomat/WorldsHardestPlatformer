using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private SpriteRenderer spriteRender;
    public List<GameObject> tokens = new List<GameObject>();

    public bool isActive = true;

    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        //Gets all tokens on Field
        tokens = GameObject.FindGameObjectsWithTag("Token").ToList<GameObject>();
        //Checks for token count to set Finish active or not
        if (tokens.Count > 0)
            isActive = false;
        
        //Changes color based on activeness
        if(!isActive)
            spriteRender.color = new Color(0, 52f / 255, 53f / 255);
        else
            spriteRender.color = new Color(0, 247f / 255, 255f / 255);
    }

    void Update()
    {
        //Checks token count and changes Finish state
        if (tokens.Count == 0)
        {
            isActive = true;
            spriteRender.color = new Color(0, 247f / 255, 255f / 255);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //When collision with Finish player gets moved one Scene
        if (other.CompareTag("Player") && isActive)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
