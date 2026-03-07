using System;
using UnityEngine;

public class TopLimit : MonoBehaviour
{
  public event Action OnEndGame;
  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Sweet"))
    {
      Sweets sweetScript = collision.gameObject.GetComponent<Sweets>();

      if (sweetScript.hasBeenDropped)
      {
        Debug.Log("game over");
        Time.timeScale = 0;
        OnEndGame?.Invoke();
      }
    }
  }
}
