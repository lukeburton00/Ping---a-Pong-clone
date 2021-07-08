using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public GameObject main;
    public GameObject controls;
    PlayerData playerData;

    void Start() 
    {
        playerData = new PlayerData();
    }
    public void OnStart()
    {
        Time.timeScale = 1f;
        playerData.mode = 1;
        Load();
    }

    public void OnStartSingleplayer()
    {
        Time.timeScale = 1f;
        playerData.mode = 0;
        Load();
    }

    void Load()
    {
        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.dataPath + "/modeSelect.json", json);
        
        SceneManager.LoadScene("Main");
    }

    public void OnControls()
    {
        main.SetActive(false);
        controls.SetActive(true);
    }

    public void OnBack()
    {
        main.SetActive(true);
        controls.SetActive(false);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
