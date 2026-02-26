using System;
using UnityEngine;

public class UI_Panel : MonoBehaviour
{
  [SerializeField] TimeManager timeManager;
  [SerializeField] private SO_PlayerDatas playerDatas;
  [SerializeField] private string gameName = "GameNWatch";
  [SerializeField] private GameObject highscorePanel;
  [SerializeField] private ScoreDatas scoreDatas;
  public GameObject loosePanel;

  public event Action Stop;
  public event Action SaveScore;
  
  private void Awake()
  {
    playerDatas.LoadDatas();
  }
  private void OnEnable()
  {
    ObjectMovement.Loose += ShowLoosePanel;
  }

  private void OnDisable()
  {
    ObjectMovement.Loose -= ShowLoosePanel;
  }
  
  public void ShowLoosePanel()
  {
    loosePanel.SetActive(true);
    Stop?.Invoke();
    SaveScore?.Invoke();
    EndGame();
  }
  
  public void EndGame()
  {
    if (playerDatas.IsHighscore(gameName, scoreDatas.ScoreValue))
    {
      playerDatas.AddHighscore(gameName, playerDatas.Name, scoreDatas.ScoreValue);
    }
    if (highscorePanel != null)
    {
      highscorePanel.SetActive(true);
    }
  }
}
