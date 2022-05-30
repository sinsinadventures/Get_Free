using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultManager : MonoBehaviour
{
    [SerializeField] Canvas _resultCanvas; 
    [SerializeField] TextMeshProUGUI _waveNumberText; 
    // [SerializeField] TextMeshProUGUI _scoreText; 
    [SerializeField] TextMeshProUGUI _finalResultText; 
    private Player _player;
    private Waves _waves;

    void Start()
    {
        _resultCanvas.enabled = false;
        _player = FindObjectOfType<Player>();
        _waves = FindObjectOfType<Waves>();
    }

    void Update()
    {
        print(_player.isDeadAgain);
        if (_waves.stopGame)
        {
            // Time.timeScale = 0;
            _resultCanvas.enabled = true;
            _finalResultText.text = "you won";
            _waveNumberText.text = "8";
        }
        if (_player.isDeadAgain)
        {
            // Time.timeScale = 0;
            _resultCanvas.enabled = true;
            _finalResultText.text = "you failed";
            _waveNumberText.text = _waves.waveNumber.ToString();
        }
    }



}
