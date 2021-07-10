using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject spawnPoint;
    private GameObject body;
    private List<SpriteRenderer> turretRender = new List<SpriteRenderer>();
    private SpriteRenderer prefabSprite;
    public GameObject prefab;

    public float spawnIntervall = 1.0f;
    public float bulletSpeed = 0.05f;
    public int dir; //0 = Right || 1 = Left
    public bool turnInvisible = false;
    public float invisible = 1f;

    void Start()
    {
        prefabSprite = prefab.GetComponent<SpriteRenderer>();

        //Get Spawnpoint, Body and List of Body Parts
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("CanonSpawn"))
                spawnPoint = transform.GetChild(i).gameObject;
            else if (transform.GetChild(i).name == "Body")
                body = transform.GetChild(i).gameObject;
            for(int j = 0; j < body.transform.childCount; j++)
                turretRender.Add(body.transform.GetChild(j).gameObject.GetComponent<SpriteRenderer>());
        }
        turretRender.Add(body.GetComponent<SpriteRenderer>());

        //Check if bullet should turn invisible
        if (turnInvisible)
        {
            for (int i = 0; i < turretRender.Count; i++)
                //Make Turret Light Purple
                turretRender[i].color = new Color(131f / 255, 86f / 255, 159f / 255);
            //Change Bullet Color to Orange
            prefabSprite.color = new Color(1, 117f / 255, 0);
        }
        else
        {
            for (int i = 0; i < turretRender.Count; i++)
                //Make Turret Purple
                turretRender[i].color = new Color(157f / 255, 0f / 255, 255f / 255);
            //Make Bullet Red
            prefabSprite.color = new Color(1, 0, 0);
        }

        //Check where Spawnpoint is Relative to Body and set dir
        if (spawnPoint.transform.position.x < body.transform.position.x)
            dir = 1;
        else
            dir = 0;
        StartCoroutine(SpawnWait());
    }

    IEnumerator SpawnWait()
    {
        yield return new WaitForSeconds(spawnIntervall);
        //Spawn Bullet at Spawnpoin
        GameObject bullet = Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity, transform);

        //Get Bullet Code and set Speed, time before Invisibility and if bullet turns invisible
        Bullet bulletCode = bullet.GetComponent<Bullet>();
        bulletCode.speed = bulletSpeed;
        bulletCode.waitForInvisible = invisible;
        bulletCode.invisible = turnInvisible;
        StartCoroutine(SpawnWait());
    }
}