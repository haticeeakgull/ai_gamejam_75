using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void Quit()
    {
        TimeControl();
        Application.Quit();
    }
    public void Play()
    {
        TimeControl();

        SceneManager.LoadScene("Start");
    }

    private void TimeControl()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
        }

    }
    public void StartButton()
    {
        

        SceneManager.LoadScene("gameScene");
    }
}
