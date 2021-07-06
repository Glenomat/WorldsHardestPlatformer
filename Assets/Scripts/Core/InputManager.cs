using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    void Start()
    { 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) // Skip
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else if (Input.GetKeyDown(KeyCode.R)) //Reload
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
