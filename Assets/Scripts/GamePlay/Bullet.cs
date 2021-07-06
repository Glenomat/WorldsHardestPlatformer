using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Turret turret;
    public float speed = 0.05f;

    void Start()
    {
        int ignoreLayerID = LayerMask.NameToLayer("Enemys");
        Physics2D.IgnoreLayerCollision(ignoreLayerID, ignoreLayerID, true);

        turret = transform.parent.GetComponent<Turret>();
    }

    void Update()
    {
        if(turret.dir == 0)
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
