using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreSuika : MonoBehaviour
{
   [SerializeField] TopLimit topLimit;
   [SerializeField] TMP_Text  scoreText;
   [SerializeField] TMP_Text PowerBarText;
   [SerializeField] private Image NextnextSweetPreview;
   [SerializeField] private SO_PlayerDatas playerDatas;
   [SerializeField] private ScoreDatas scoreDatas;
   [SerializeField] private string gameName = "SuikaGame";
   [SerializeField] private GameObject highscorePanel;
   [SerializeField] private TMP_Text highscoreText;
   [SerializeField] private TMP_Text FinalscoreText;
   [SerializeField] public Animator uiGameOverAnimator;
   [SerializeField] public Animator uiPresentationAnimator;
   [SerializeField] SliderController sliderController;
   private int currentScore = 0;
   private int PowerBar = 0;
   private int ScoreToActivatePower = 100;
   
   [SerializeField] public Animator uiLevelUpAnimator;
   [SerializeField] public Animator uiFireWorkAnimator;
   
   [SerializeField] private AudioEventDispatcher _audioEventDispatcher;
   [SerializeField] private AudioType _death;
   [SerializeField] private AudioType _levelup;
   
   [SerializeField] private AudioSource _audioSource;
   [SerializeField] private AudioClip _newReccordClip;
   
   public static bool AlreadyPlayed = false;

   public event Action SpawnFloor;
   public static event Action DeleteMalus;
   private void Start()
   {
      uiPresentationAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
      uiGameOverAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
      _audioSource.Play();
      if (AlreadyPlayed)
      {
         //foreach (GameObject go in TutoElements)
         //{
            //go.SetActive(false);
         //}

         StartCoroutine(WaitBeforePlay());

      }
      else
      {
         uiPresentationAnimator.SetTrigger("Spawned"); 
      }
      Time.timeScale = 0;
      currentScore = 0;
   }
   
   IEnumerator WaitBeforePlay()
   {
      yield return new WaitForSecondsRealtime(1.3f);
      Time.timeScale = 1;
   }

   private void OnEnable()
   {
      Sweets.GainPoints += IncreaseScore;
      CharacterMovement.OnNextnextSweetChanged += UpdateNextnextSweetDisplay;
      topLimit.OnEndGame += EndGame;
   }

   private void OnDisable()
   {
      Sweets.GainPoints -= IncreaseScore;
      CharacterMovement.OnNextnextSweetChanged-= UpdateNextnextSweetDisplay;
      topLimit.OnEndGame -= EndGame;
   }

   public void IncreaseScore(int value)
   {
      currentScore += value;
      PowerBar += value;
      scoreText.text = $"Score : {currentScore.ToString()}";
      sliderController.UpdateProgress(PowerBar);
      PowerBarText.text = $"PowerBar : {PowerBar.ToString()}";
      // Affichage barre qui augmente
      if (PowerBar >= ScoreToActivatePower)
      {
         PowerBar = 0;
         DeleteMalus?.Invoke();
         SpawnFloor?.Invoke();
         uiLevelUpAnimator.SetTrigger("LevelUp");
         uiFireWorkAnimator.SetTrigger("LevelUp");
         _audioEventDispatcher.Playaudio(_levelup);
      }
   }

   private void UpdateNextnextSweetDisplay(Sprite sprite)
   {
      NextnextSweetPreview.sprite = sprite;
   }
   
   public void EndGame()
   {
      _audioSource.Stop();
      _audioSource.volume = 0.5f;
      AlreadyPlayed = true;
      _audioEventDispatcher.Playaudio(_death);
      uiGameOverAnimator.SetTrigger("Loose");
      if (playerDatas.IsBestScore(gameName, currentScore))
      {
         highscoreText.gameObject.SetActive(true);
         _audioSource.PlayOneShot(_newReccordClip);
      }
      if (playerDatas.IsHighscore(gameName, currentScore))
      {
         playerDatas.AddHighscore(gameName, playerDatas.Name, currentScore);
      }
      FinalscoreText.text = $"Score: {currentScore.ToString()}";
   }
}
