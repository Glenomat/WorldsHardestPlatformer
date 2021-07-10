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

        //Ignore Layer Enemys for pass-through
        int ignoreLayerID = LayerMask.NameToLayer("Enemys");
        Physics2D.IgnoreLayerCollision(ignoreLayerID, ignoreLayerID, true);

        //Get Turret Script from Parent Turret
        turret = transform.parent.GetComponent<Turret>();
        if (invisible)
            StartCoroutine(TurnInvisible());
    }

    void Update()
    {
        //When Paused no bullet movement
        if (pauseScreen.activeSelf) return;
        //Check dir and move bullet in correct direction
        if(turret.dir == 0)
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    IEnumerator TurnInvisible()
    {
        //Turns bullet after X amount of seconds invisible
        yield return new WaitForSeconds(waitForInvisible);
        //Sets bullet aplha to 50 for almost invisibility
        bulletRender.color = new Color(bulletRender.color.r, bulletRender.color.g, bulletRender.color.b, 50f / 255);
    }
}
