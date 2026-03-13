using System;
using System.Collections;
using UnityEngine;

public class TopLimit : MonoBehaviour
{
  public event Action SpawnLastFloor;
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
        SpawnLastFloor?.Invoke();
        SuikaGameOver = true;
        StartCoroutine(CooldownBeforeGameOver());
      }
    }
  }

  IEnumerator CooldownBeforeGameOver()
  {
    yield return new WaitForSeconds(1f);
    Time.timeScale = 0;
    OnEndGame?.Invoke();
  }
}
