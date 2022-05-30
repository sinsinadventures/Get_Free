using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    public void ResetGame()
    {
        SceneManager.LoadScene("FirstLevel_Improved");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
