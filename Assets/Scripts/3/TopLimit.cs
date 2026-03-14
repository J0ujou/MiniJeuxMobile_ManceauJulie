using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TopLimit : MonoBehaviour
{
  public event Action SpawnLastFloor;
  public event Action OnEndGame;
  public bool SuikaGameOver =false;
  [SerializeField] GameObject GameOverPanel;
  [SerializeField] TMP_Text FloorText;

  private void Start()
  {
    GameOverPanel.SetActive(false);
    SuikaGameOver = false;
  }
  private void OnTriggerStay2D(Collider2D collision)
  {
    if (SuikaGameOver) return;
    
    if (collision.gameObject.CompareTag("Sweet"))
    {
      Sweets sweetScript = collision.gameObject.GetComponent<Sweets>();

      if (sweetScript.hasBeenDropped)
      {
        SuikaGameOver = true;
        StartCoroutine(CooldownBeforeGameOver());
        GameOverPanel.SetActive(true);
      }
    }
  }

  IEnumerator CooldownBeforeGameOver()
  {
    SpawnLastFloor?.Invoke();
    yield return new WaitForSeconds(1f);
    Time.timeScale = 0;
    OnEndGame?.Invoke();
  }

  public void NbFloorText(int nb)
  {
    FloorText.text = $"Etages: {nb.ToString()}";
  }
} 
