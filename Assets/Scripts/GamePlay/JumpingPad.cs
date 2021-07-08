using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPad : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rbPlayer;

    public float velocityY = 5f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").gameObject;
        rbPlayer = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, velocityY);
        }
    }
}
