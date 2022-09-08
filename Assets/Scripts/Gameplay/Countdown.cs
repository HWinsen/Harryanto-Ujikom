using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    private float Remaining;
    Text coundownText;

    // Start is called before the first frame update
    void Start()
    {
        Remaining = 30;
        coundownText = GetComponent<Text>();
        coundownText.text = Remaining.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Remaining > 0)
        {
            StartCountdown();
        }
        else
        {
            StopCountdown();
        }
    }

    public void StartCountdown()
    {
        //Debug.Log(Convert.ToInt64(Time.deltaTime));

        //string timeString = string.Format("{0:0.0000}", Time.deltaTime);
        //Remaining -= long.Parse(timeString.Replace(".", ""));

        //Remaining -= Convert.ToInt64(Time.deltaTime);
        //Remaining -= Time.deltaTime;

        //float tempSec = 0;
        //tempSec += Time.deltaTime;
        //Remaining -= Convert.ToInt64(MathF.Round(tempSec));
        //if (tempSec > 1) tempSec = 0;
        //Debug.Log(tempSec);

        Remaining -= Time.deltaTime;
        coundownText.text = Remaining.ToString();
    }

    public void StopCountdown()
    {
        Time.timeScale = 0;
    }

    public void FinishCountdown()
    {

    }
}
