using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public GameObject pauseScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) // Skip
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else if (Input.GetKeyDown(KeyCode.R)) //Reload
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeSelf)
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
