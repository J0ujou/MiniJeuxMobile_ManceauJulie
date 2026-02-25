using System.Collections.Generic;
using UnityEngine;

public class HighscoreDisplayManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private string gameName = "RunNJump";
    [SerializeField] private SO_PlayerDatas playerDatas;
    
    [Header("UI References")]
    [SerializeField] private Transform entriesContainer;
    [SerializeField] private GameObject entryPrefab;
    [SerializeField] private int maxEntriesToShow = 10;

    private List<HighScoreEntryUI> entryUIList = new List<HighScoreEntryUI>();

    private void Start()
    {
        if (playerDatas != null)
        {
            playerDatas.LoadDatas();
        }
    }

    private void OnEnable()
    {
        DisplayHighscores();
    }

    public void DisplayHighscores()
    {
        ClearEntries();
        
        List<HighscoreEntry> highscores = playerDatas.GetHighscoreList(gameName);
        
        if (highscores == null || highscores.Count == 0)
        {
            Debug.Log($"Aucun highscore pour {gameName}");
            return;
        }
        
        int count = Mathf.Min(highscores.Count, maxEntriesToShow);
        
        for (int i = 0; i < count; i++)
        {
            GameObject entryObj = Instantiate(entryPrefab, entriesContainer);
            HighScoreEntryUI entryUI = entryObj.GetComponent<HighScoreEntryUI>();
            
            if (entryUI != null)
            {
                entryUI.SetData(i + 1, highscores[i].playerName, highscores[i].Score);
                entryUIList.Add(entryUI);
            }
        }
    }

    private void ClearEntries()
    {
        foreach (HighScoreEntryUI i in entryUIList)
        {
            if (i != null)
                Destroy(i.gameObject);
        }
        entryUIList.Clear();
    }
}