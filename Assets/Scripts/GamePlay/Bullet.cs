using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Turret turret;
    private GameObject pauseScreen;
    private SpriteRenderer bulletRender;
    public float speed = 0.05f;
    public float waitForInvisible = 1f;
    public bool invisible = false;

    void Start()
    {
        pauseScreen = GameObject.Find("Ui").transform.GetChild(0).gameObject;
        bulletRender = GetComponent<SpriteRenderer>();

        int ignoreLayerID = LayerMask.NameToLayer("Enemys");
        Physics2D.IgnoreLayerCollision(ignoreLayerID, ignoreLayerID, true);

        turret = transform.parent.GetComponent<Turret>();
        if (invisible)
            StartCoroutine(TurnInvisible());
    }

    void Update()
    {
        if (pauseScreen.activeSelf) return;
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

    IEnumerator TurnInvisible()
    {
        yield return new WaitForSeconds(waitForInvisible);
        bulletRender.color = new Color(bulletRender.color.r, bulletRender.color.g, bulletRender.color.b, 50f / 255);
    }
}
