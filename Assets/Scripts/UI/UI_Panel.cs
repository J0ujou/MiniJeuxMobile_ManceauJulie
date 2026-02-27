using System;
using TMPro;
using UnityEngine;

public class UI_Panel : MonoBehaviour
{
  [SerializeField] TimeManager timeManager;
  [SerializeField] private SO_PlayerDatas playerDatas;
  [SerializeField] private string gameName = "GameNWatch";
  [SerializeField] private GameObject highscorePanel;
  [SerializeField] private ScoreDatas scoreDatas;
  public GameObject loosePanel;
  public GameObject levelUpPanel;
  [SerializeField] private TMP_Text highscoreText;
  [SerializeField] private TMP_Text scoreText;
  public bool LooseGameNWatch = false;

  public event Action Stop;
  public event Action SaveScore;
  
  private void Start()
  {
    playerDatas.LoadDatas();
    highscorePanel.SetActive(false);
    loosePanel.SetActive(false);
    highscoreText.gameObject.SetActive(false);
    timeManager.StopTime();
  }
  private void OnEnable()
  {
    ObjectMovement.Loose += ShowLoosePanel;
    PlayerCollect.OnLevelUp += ShowLevelUp;
  }

  private void OnDisable()
  {
    ObjectMovement.Loose -= ShowLoosePanel;
    PlayerCollect.OnLevelUp -= ShowLevelUp;
  }


  public void ShowLevelUp()
  {
    levelUpPanel.SetActive(true);
  }
  public void ShowLoosePanel()
  {
    loosePanel.SetActive(true);
    Stop?.Invoke();
    SaveScore?.Invoke();
    EndGame();
    LooseGameNWatch = true;
  }
  
  public void EndGame()
  {
    if (playerDatas.IsBestScore(gameName, scoreDatas.ScoreValue))
    {
      highscoreText.gameObject.SetActive(true);
      Debug.Log("BEST");
    }
    if (playerDatas.IsHighscore(gameName, scoreDatas.ScoreValue))
    {
      playerDatas.AddHighscore(gameName, playerDatas.Name, scoreDatas.ScoreValue);
    }
    scoreText.text = $"Score: {scoreDatas.ScoreValue}";
    //if (highscorePanel != null)
    //{
      //highscorePanel.SetActive(true);
    //}
  }
}
