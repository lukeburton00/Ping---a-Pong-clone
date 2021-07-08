using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartSinglePlayer()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainOnePlayer");
    }
}
