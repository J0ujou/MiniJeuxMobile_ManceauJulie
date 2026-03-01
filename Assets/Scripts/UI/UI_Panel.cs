using System;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

public class UI_Panel : MonoBehaviour
{
  [SerializeField] TimeManager timeManager;
  [SerializeField] private SO_PlayerDatas playerDatas;
  [SerializeField] private string gameName = "GameNWatch";
  [SerializeField] private GameObject highscorePanel;
  [SerializeField] private ScoreDatas scoreDatas;
  public GameObject loosePanel;
  public bool play=false;
  [SerializeField] private TMP_Text highscoreText;
  [SerializeField] private TMP_Text scoreText;
  
  [SerializeField] private AudioEventDispatcher _audioEventDispatcher;
  [SerializeField] private AudioType _death;
  
  public bool LooseGameNWatch = false;
  public static bool AlreadyPlayed = false;
  
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
    if (AlreadyPlayed)
    {
      return;
    }
    else
    {
      uiCandyRainAnimator.SetTrigger("Spawned");
      timeManager.StopTime();
    }
    play = false;
    playerDatas.LoadDatas();
    highscorePanel.SetActive(false);
    loosePanel.SetActive(false);
    highscoreText.gameObject.SetActive(false);
    
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
    _audioSource.Stop();
    _audioSource.loop = false;
    _audioSource.volume = 1f;
    _audioEventDispatcher.Playaudio(_death);
    loosePanel.SetActive(true);
    Stop?.Invoke();
    SaveScore?.Invoke();
    EndGame();
    LooseGameNWatch = true;
    uiCandyRainGameOverAnimator.SetTrigger("Loose");
  }
  
  public void EndGame()
  {
    if (playerDatas.IsBestScore(gameName, scoreDatas.ScoreValue))
    {
      highscoreText.gameObject.SetActive(true);
      _audioSource.PlayOneShot(_newReccordClip);
    }
    if (playerDatas.IsHighscore(gameName, scoreDatas.ScoreValue))
    {
      playerDatas.AddHighscore(gameName, playerDatas.Name, scoreDatas.ScoreValue);
    }
    scoreText.text = $"Score: {scoreDatas.ScoreValue}";
  }

  public void PlayPressed()
  {
    play = true;
    if (AlreadyPlayed)
    {
      return;
    }
    else
    {
      uiCandyRainAnimator.SetTrigger("PlayPressed");
      AlreadyPlayed=true;
    }
  }
}
