using System;
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
   [SerializeField] public Animator uiCandyRainGameOverAnimator;
   private int currentScore = 0;
   private int PowerBar = 0;
   private int ScoreToActivatePower = 100;


   public static event Action DeleteMalus;
   private void Start()
   {
      currentScore = 0;
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
      PowerBarText.text = $"PowerBar : {PowerBar.ToString()}";
      // Affichage barre qui augmente
      if (PowerBar >= ScoreToActivatePower)
      {
         PowerBar = 0;
         DeleteMalus?.Invoke();
      }
   }

   private void UpdateNextnextSweetDisplay(Sprite sprite)
   {
      NextnextSweetPreview.sprite = sprite;
   }
   
   public void EndGame()
   {
      Debug.Log("EndGame");
      //_audioEventDispatcher.Playaudio(_death);
      //SaveScore?.Invoke();
      uiCandyRainGameOverAnimator.SetTrigger("Loose");
      if (playerDatas.IsBestScore(gameName, currentScore))
      {
         highscoreText.gameObject.SetActive(true);
         //_audioSource.PlayOneShot(_newReccordClip);
      }
      if (playerDatas.IsHighscore(gameName, currentScore))
      {
         playerDatas.AddHighscore(gameName, playerDatas.Name, currentScore);
      }
      FinalscoreText.text = $"Score: {currentScore.ToString()}";
      highscorePanel.SetActive(true);
   }
}
