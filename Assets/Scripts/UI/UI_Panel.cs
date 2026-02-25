using System;
using UnityEngine;

public class UI_Panel : MonoBehaviour
{
  [SerializeField] TimeManager timeManager;
  public GameObject loosePanel;

  public event Action Stop;
  public event Action SaveScore;
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
  }

  public void ShowHighScore()
  {
    // si le score actuel est plus grand que l'autre alors highscore
    // voir après pour faire un tableau
  }
}
