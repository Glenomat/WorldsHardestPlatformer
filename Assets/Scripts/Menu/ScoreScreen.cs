using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{
    public Text deathTxt;
    public Text lvlTxt;
    public Text timeTxt;

    private static int sec = 0;
    private static int minutes = 0;
    private static int hours = 0;
    private string res = "";

    void Start()
    {
        StartCoroutine(TimeCalc());
    }

    IEnumerator TimeCalc()
    {
        res = "";
        sec++;
        if (sec == 60)
        {
            sec = 0;
            minutes++;
        }
        if (minutes == 60)
        {
            minutes = 0;
            hours++;
        }

        if (hours >= 10)
            res += hours + ":";
        else
            res += "0" + hours + ":";
        if (minutes >= 10)
            res += minutes + ":";
        else
            res += "0" + minutes + ":";
        if (sec >= 10)
            res += sec;
        else
            res += "0" + sec;

        timeTxt.text = res;
        yield return new WaitForSecondsRealtime(1);
        StartCoroutine(TimeCalc());
    }
}
