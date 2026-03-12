using System;
using UnityEngine;

public class TopLimit : MonoBehaviour
{
  public event Action OnEndGame;
  public bool SuikaGameOver =false;

  private void Start()
  {
    SuikaGameOver = false;
  }
  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Sweet"))
    {
      Sweets sweetScript = collision.gameObject.GetComponent<Sweets>();

      if (sweetScript.hasBeenDropped)
      {
        SuikaGameOver = true;
        Time.timeScale = 0;
        OnEndGame?.Invoke();
      }
    }
  }
}
