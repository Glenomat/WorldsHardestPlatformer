using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour
{
    public Text deathTxt;
    public Text lvlTxt;
    public Text timeTxt;

    private static float time = 0f;
    TimeSpan totalTime;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenue")
        {
            time = 0f;
            return;
        }
        if(SceneManager.GetActiveScene().name == "FinalScreen")
        {
            totalTime = TimeSpan.FromSeconds(time);
            timeTxt.text = "You'r final time is: " + String.Format("{0:00}:{1:00}:{2:00}", totalTime.Hours, totalTime.Minutes, totalTime.Seconds);
            time = 0f;
            return;
        }
        lvlTxt.text = "Level " + SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "FinalScreen" || SceneManager.GetActiveScene().name == "MainMenue") return;
        time += Time.deltaTime;
        totalTime = TimeSpan.FromSeconds(time);
        timeTxt.text = "Time: " + String.Format("{0:00}:{1:00}:{2:00}", totalTime.Hours, totalTime.Minutes, totalTime.Seconds);
    }

    public void MainMenue()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
