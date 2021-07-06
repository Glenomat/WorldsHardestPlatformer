using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject spawnPoint;
    private GameObject body;
    public GameObject prefab;

    public float spawnIntervall = 1.0f;
    public float bulletSpeed = 0.05f;
    public int dir; //0 = Right || 1 = Left

    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("CanonSpawn"))
                spawnPoint = transform.GetChild(i).gameObject;
            else if (transform.GetChild(i).name == "Body")
                body = transform.GetChild(i).gameObject;

        }

        if (spawnPoint.transform.position.x < body.transform.position.x)
            dir = 1;
        else
            dir = 0;
        StartCoroutine(SpawnWait());
    }

    IEnumerator SpawnWait()
    {
        yield return new WaitForSeconds(spawnIntervall);
        GameObject bullet = Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity, transform);
        Bullet bulletCode = bullet.GetComponent<Bullet>();
        bulletCode.speed = bulletSpeed;
        StartCoroutine(SpawnWait());
    }
}