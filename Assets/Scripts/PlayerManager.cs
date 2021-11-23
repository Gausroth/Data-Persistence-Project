using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public string PlayerName;
    public string BestScoreName;
    public int BestScore;

    public static PlayerManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string BestScoreName;
        public int BestScore;
    }

    public void SavePlayerScore()
    {
        SaveData data = new SaveData();
        data.BestScoreName = PlayerName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScoreName = data.BestScoreName;
            BestScore = data.BestScore;
        }
    }

    public void DeletePlayerScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(path);

            BestScoreName = "";
            BestScore = 0;
        }
    }
}
