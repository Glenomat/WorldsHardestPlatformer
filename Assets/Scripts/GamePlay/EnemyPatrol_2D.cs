using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol_2D : MonoBehaviour
{
    public GameObject castPos;
    [SerializeField] LayerMask layerMask;
    private BoxCollider2D boxCollider;

    public float speed = 0.5f;
    public float rayLength = 0.05f;
    public bool forceDir = false;
    public int dir = 0; // 0 = right || 1 = Left
    private float disCastPos;

    void Start()
    {
        int ignoreLayerID = LayerMask.NameToLayer("Enemys");
        Physics2D.IgnoreLayerCollision(ignoreLayerID, ignoreLayerID, true);

        boxCollider = GetComponent<BoxCollider2D>();
        castPos.transform.position = new Vector2(transform.position.x + boxCollider.bounds.extents.x, transform.position.y - (boxCollider.bounds.extents.y - 0.1f));
        disCastPos = Vector2.Distance(castPos.transform.position, new Vector2(transform.position.x + boxCollider.bounds.extents.x, transform.position.y - boxCollider.bounds.extents.y));
        if(!forceDir)
            dir = Random.Range(0, 2);

        RaycastHit2D groundCast = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + 1f, layerMask);
        Debug.Log(groundCast.distance.ToString());
        transform.position = new Vector2(transform.position.x, transform.position.y - groundCast.distance);
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
