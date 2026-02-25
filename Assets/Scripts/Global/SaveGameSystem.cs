using System;
using UnityEngine;

public class SaveGameSystem : MonoBehaviour
{
    [SerializeField] private SO_PlayerDatas playerDatas;
    [SerializeField] private UI_Panel scorefinal;

    public void OnEnable()
    {
        scorefinal.SaveScore += SaveGame;
    }

    public void OnDisable()
    {
        scorefinal.SaveScore -= SaveGame;
    }

    public void LoadSaveGame()
    {
        playerDatas.LoadDatas();
    }

    public void SaveGame()
    {
        playerDatas.SaveDatas();
    }
    
}
