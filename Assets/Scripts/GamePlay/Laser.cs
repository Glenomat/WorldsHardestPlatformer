using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Laser : MonoBehaviour
{
    private GameObject diode1;
    private GameObject diode2;
    private GameObject laser;

    public bool useOnOffTime = false;
    public float onTime = 1f;
    public float offTime = 1f;
    public bool levelY = false;
    public bool levelX = false;
    private bool on = false;

    void Start()
    {
        diode1 = transform.GetChild(0).gameObject;
        diode2 = transform.GetChild(1).gameObject;
        laser = transform.GetChild(2).gameObject;

        if (levelX)
            diode2.transform.position = new Vector2(diode1.transform.position.x, diode2.transform.position.y);
        if (levelY)
            diode2.transform.position = new Vector3(diode2.transform.position.x, diode1.transform.position.y);

        //Make diodes Look at Each other with correct rotation
        if(diode1.transform.position.x == diode2.transform.position.x)
            diode1.transform.rotation = Quaternion.Euler(0, 0, 90);
        else
        {
            diode1.transform.LookAt(diode2.transform, Vector3.zero);
            diode1.transform.rotation = Quaternion.Euler(0, 0, diode1.transform.rotation.eulerAngles.z * -1f);
        }
        diode2.transform.rotation = diode1.transform.rotation;

        //Fix Z Position
        diode1.transform.position = new Vector3(diode1.transform.position.x, diode1.transform.position.y, 0);
        diode2.transform.position = new Vector3(diode2.transform.position.x, diode2.transform.position.y, 0);

        //Place Laser Between Diodes
        laser.transform.position = new Vector2(diode1.transform.position.x - (diode1.transform.position.x - diode2.transform.position.x) / 2, diode1.transform.position.y - (diode1.transform.position.y - diode2.transform.position.y) / 2);
        
        //Rotate Laser based on Diode1
        laser.transform.rotation = diode1.transform.rotation;
        
        //Scale Laser according to diodes
        laser.transform.localScale = new Vector3(Vector2.Distance(diode1.transform.position, diode2.transform.position), diode1.transform.localScale.y / 2, 0);
        StartCoroutine(LaserSwitch());
    }

    IEnumerator LaserSwitch()
    {
        laser.SetActive(on);
        on = !on;

        if (useOnOffTime)
        {
            if (on)
                yield return new WaitForSeconds(offTime);
            else
                yield return new WaitForSeconds(onTime);
        }
        else
            yield return new WaitForSeconds(onTime);

        StartCoroutine(LaserSwitch());
    }
}