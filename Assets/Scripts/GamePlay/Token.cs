using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    Finish finish;
    void Start()
    {
        finish = GameObject.FindWithTag("Finish").GetComponent<Finish>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            finish.tokens.Remove(gameObject);
            gameObject.SetActive(false);
        }
    }
}
