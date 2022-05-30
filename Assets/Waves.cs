using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Waves : MonoBehaviour
{
    [SerializeField] Canvas _waveCanvas; 
    [SerializeField] private float _wavePeriod = 10;
    [SerializeField] TextMeshProUGUI _waveNumberText; 
    public int waveNumber = 1;
    public bool stopGame = false;
    private Timer _timer;
    private float _lastTime = 0;

    private void Start() 
    {
        _waveCanvas.enabled = false;
        _timer = FindObjectOfType<Timer>();    
    }


    private void Update() {
        if (stopGame) return;
        if (_timer.timerIsRunning)
        {
            ManageWaves();
            _waveCanvas.enabled = true;
            _waveNumberText.text = waveNumber.ToString();
        }

    }

    private void ManageWaves()
    {
        if (_timer.time >= _lastTime + _wavePeriod)
        {
            _lastTime += _wavePeriod;
            waveNumber ++;
            if (waveNumber == 9)
            {
                StopGame();
            }
        }
    }

    private void StopGame()
    {
        stopGame = true;
    }
}
