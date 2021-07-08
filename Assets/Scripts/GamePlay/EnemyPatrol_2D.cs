using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol_2D : MonoBehaviour
{
    public GameObject castPos;
    [SerializeField] LayerMask layerMask;
    private BoxCollider2D boxCollider;
    private BoxCollider2D groundBoxCollider;

    public float speed = 0.5f;
    public float rayLength = 0.05f;
    public bool forceDir = false;
    public int dir = 0; // 0 = right || 1 = Left
    private float disCastPos;

    void Start()
    {
        //Ignore Enemy Layer
        int ignoreLayerID = LayerMask.NameToLayer("Enemys");
        Physics2D.IgnoreLayerCollision(ignoreLayerID, ignoreLayerID, true);

        boxCollider = GetComponent<BoxCollider2D>();

        //Set CastPos infront of Enemy
        castPos.transform.position = new Vector2(transform.position.x + boxCollider.bounds.extents.x, transform.position.y - (boxCollider.bounds.extents.y - 0.1f));
        disCastPos = Vector2.Distance(castPos.transform.position, new Vector2(transform.position.x + boxCollider.bounds.extents.x, transform.position.y - boxCollider.bounds.extents.y));


        RaycastHit2D groundCast = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + 1f, layerMask);
        groundBoxCollider = groundCast.transform.gameObject.GetComponent<BoxCollider2D>();

        transform.position = new Vector2(transform.position.x, ((groundCast.transform.position.y + groundBoxCollider.bounds.extents.y) + boxCollider.bounds.extents.y) + 0.01f);
        //transform.position = new Vector2(transform.position.x, transform.position.y - (groundCast.distance - groundBoxCollider.bounds.extents.y));

        if (!forceDir)
            dir = Random.Range(0, 2);
    }

    void Update()
    {
        RaycastHit2D castVerti = Physics2D.Raycast(castPos.transform.position, Vector2.down, disCastPos + rayLength, layerMask);
        RaycastHit2D castHori = Physics2D.Raycast(castPos.transform.position, Vector2.right, rayLength, layerMask);

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (!castVerti.collider || castHori)
        {
            if (dir == 0)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                dir = 1;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                dir = 0;
            }
        }
    }
}
