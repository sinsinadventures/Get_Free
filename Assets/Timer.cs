using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float time = 0;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    
    private void Start()
    {
        timerIsRunning = false;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        // timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
