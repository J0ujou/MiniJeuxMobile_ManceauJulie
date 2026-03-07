using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreSuika : MonoBehaviour
{
   [SerializeField] TMP_Text  scoreText;
   [SerializeField] TMP_Text PowerBarText;
   [SerializeField] private Image NextnextSweetPreview;
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
   }

   private void OnDisable()
   {
      Sweets.GainPoints -= IncreaseScore;
      CharacterMovement.OnNextnextSweetChanged-= UpdateNextnextSweetDisplay;
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
}
