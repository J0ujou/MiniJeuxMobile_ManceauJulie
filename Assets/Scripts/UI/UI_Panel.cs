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
  [SerializeField] private AudioEventDispatcher _audioEventDispatcher;
  [SerializeField] private AudioType _death;
  [SerializeField] private AudioType _newReccord;
  public bool LooseGameNWatch = false;
  [SerializeField] private AudioSource _audioSource;
  [SerializeField] private AudioClip _newReccordClip;
  
  [SerializeField] public Animator uiCandyRainAnimator;
  [SerializeField] public Animator uiCandyRainGameOverAnimator;
  [SerializeField] public Animator uiCandyRainLevelUpAnimator;
  [SerializeField] public Animator uiCandyRainFireworkAnimator;

  public event Action Stop;
  public event Action SaveScore;
  
  private void Start()
  {
    playerDatas.LoadDatas();
    highscorePanel.SetActive(false);
    loosePanel.SetActive(false);
    highscoreText.gameObject.SetActive(false);
    timeManager.StopTime();
    uiCandyRainAnimator.SetTrigger("Spawned");
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
    uiCandyRainFireworkAnimator.SetTrigger("LevelUp");
    uiCandyRainLevelUpAnimator.SetTrigger("LevelUp");
  }
  public void ShowLoosePanel()
  {
    loosePanel.SetActive(true);
    Stop?.Invoke();
    SaveScore?.Invoke();
    EndGame();
    LooseGameNWatch = true;
    _audioEventDispatcher.Playaudio(_death);
    uiCandyRainGameOverAnimator.SetTrigger("Loose");
  }
  
  public void EndGame()
  {
    if (playerDatas.IsBestScore(gameName, scoreDatas.ScoreValue))
    {
      highscoreText.gameObject.SetActive(true);
      Debug.Log("BEST");
      _audioSource.PlayOneShot(_newReccordClip);
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

  public void PlayPressed()
  {
    uiCandyRainAnimator.SetTrigger("PlayPressed");
  }
}
