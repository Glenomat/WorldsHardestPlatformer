using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingPlatform : MonoBehaviour
{
    private SpriteRenderer platformRender;
    private BoxCollider2D platformCollider;

    public bool switchOn = false;
    public bool useOnOffIntervall = false;
    public float onTime = 1f;
    public float offTime = 2f;

    private bool isOn = true;

    void Start()
    {
        platformRender = GetComponent<SpriteRenderer>();
        platformCollider = GetComponent<BoxCollider2D>();
        if (switchOn)
            StartCoroutine(SwitchState());
    }

    IEnumerator SwitchState()
    {
        if (useOnOffIntervall)
        {
            if (isOn)
                yield return new WaitForSeconds(onTime);
            else
                yield return new WaitForSeconds(offTime);
        }
        else
            yield return new WaitForSeconds(onTime);
        if (isOn)
        {
            platformRender.color = new Color(platformRender.color.r, platformRender.color.g, platformRender.color.b, 50f / 255);
            platformCollider.enabled = false;
        }
        else
        {
            platformRender.color = new Color(platformRender.color.r, platformRender.color.g, platformRender.color.b, 1);
            platformCollider.enabled = true;
        }
        isOn = !isOn;
        StartCoroutine(SwitchState());
    }
}
