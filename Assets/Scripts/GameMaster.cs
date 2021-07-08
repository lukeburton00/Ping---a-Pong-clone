using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameMaster : MonoBehaviour
{
    public bool isSinglePlayer;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerData playerData = new PlayerData();
        string json = File.ReadAllText(Application.dataPath + "/modeSelect.json");

        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);

        if (loadedPlayerData.mode == 0)
        {
            isSinglePlayer = true;
        }

        if (loadedPlayerData.mode == 1)
        {
            isSinglePlayer = false;
        }
    }
}
