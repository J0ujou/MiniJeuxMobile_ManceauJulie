using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]

public class PlayerDatas   
{
    public string Name = "None";
    public int Score =0;
    public int Level = 1;
    public List<HighscoreEntry> highscoresRNJ = new List<HighscoreEntry>();
    public List<HighscoreEntry> highscoresGNW = new List<HighscoreEntry>();
    public List<HighscoreEntry> highscoresSG = new List<HighscoreEntry>();

}

[System.Serializable] 
public class HighscoreEntry
{
    public string playerName = "None";
    public int Score =0;

    public HighscoreEntry(string name, int scoreValue)
    {
        playerName = name;
        Score = scoreValue;
    }
}
public class SaveController
{
    public string GetPath()
    {
        return Application.persistentDataPath + "/save.json";
    }
    
    public void Save(PlayerDatas datas)
    {
        string json = JsonUtility.ToJson(datas, true);
        File.WriteAllText(GetPath(), json);
    }

    public PlayerDatas Load()
    {
        if (File.Exists(GetPath()))
        {
            string json = File.ReadAllText(GetPath());
            return JsonUtility.FromJson<PlayerDatas>(json);
        }
        return new PlayerDatas();
    }
    
}
