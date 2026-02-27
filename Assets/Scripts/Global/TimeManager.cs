using System;
using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
  [SerializeField] private float _timeStepDuration = 1.0f;
  [SerializeField] PlayerCollect playerCollect;
  [SerializeField] ScoreDatas scoreDatas;
  [SerializeField] Spawner spawner;
  [SerializeField] UI_Panel uiPanel;

  private Coroutine _timerCoroutine;
  public event Action OnTimePassed;

  private void OnEnable()
  {
    playerCollect.LevelUpDifficulty += FallSpeed;
    uiPanel.Stop += StopTime;
  }

  private void OnDisable()
  {
    playerCollect.LevelUpDifficulty -= FallSpeed;
    uiPanel.Stop -= StopTime;
  }
  
  IEnumerator SpendingTime()
  {
    while (true)
    {
      yield return new WaitForSeconds(_timeStepDuration);
      OnTimePassed?.Invoke();
    }
  }

  private void Start()
  {
    StartTime();
  }

  public void FallSpeed()
  {
    spawner.ReduceSpawnDelay();
    if (scoreDatas.ScoreValue > 30)
    {
      _timeStepDuration= Mathf.Clamp(_timeStepDuration - 0.1f, 0.5f, 1f);
    }
  }
  public void StartTime()
  {
    if (_timerCoroutine == null)
    {
      _timerCoroutine = StartCoroutine(SpendingTime());
    }
  }

  public void StopTime()
  {
    if (_timerCoroutine != null)
    {
      StopAllCoroutines();
      _timerCoroutine = null;
    }

  }
}
