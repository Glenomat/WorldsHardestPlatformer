using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_2D : MonoBehaviour
{
    [SerializeField] public LayerMask layerMask;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;

    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public float raycast = 0.5f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        else if (Input.GetAxisRaw("Horizontal") < 0)
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
        
        if(GroundCheck() && Input.GetAxisRaw("Horizontal") == 0)
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);

        if (Input.GetAxisRaw("Jump") > 0 && GroundCheck())
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
    }

    bool GroundCheck()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + raycast, layerMask);
        return rayHit;
    }
}
