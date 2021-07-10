using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightChanger : MonoBehaviour
{
    public bool changeIntensity = true;
    public float intensity = 0.5f;
    public bool changeRadius = false;
    public float reduceRadius = 0.5f;
    private Light2D playerLight;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerLight = other.gameObject.GetComponent<Light2D>();
        if(changeIntensity)
            playerLight.intensity = intensity;
        if(changeRadius)
        {
            playerLight.pointLightInnerRadius -= reduceRadius;
            playerLight.pointLightOuterRadius -= reduceRadius;
        }
        gameObject.SetActive(false);
    }
}
