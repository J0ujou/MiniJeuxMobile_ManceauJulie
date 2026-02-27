using System;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
  [SerializeField] private ScoreDatas _scoreDatas;
  [SerializeField] private SO_PlayerDatas _playerDatas;
  [SerializeField] private int LevelPoint = 10;
  private int point = 0;
  [SerializeField] private AudioEventDispatcher _audioEventDispatcher;
  [SerializeField] private AudioType _pickup;
  [SerializeField] private AudioType _levelup;

// Events
  public static Action<int> OntargetCollected;
  public static event Action OnLevelUp;
  public event Action LevelUpDifficulty;

  public void UpdateScore(int value)
  {
    _scoreDatas.ScoreValue += value;
    _playerDatas.Score = _scoreDatas.ScoreValue;
    point += 1;
    _audioEventDispatcher.Playaudio(_pickup);
    
    if (point == LevelPoint)
    {
      //_scoreDatas.Level += 1;
      //_playerDatas.Level = _scoreDatas.Level
      OnLevelUp?.Invoke();
      //_scoreDatas.ScoreValue = 0;
      //_playerDatas.Score = _scoreDatas.ScoreValue;
      LevelUpDifficulty?.Invoke();
      OntargetCollected?.Invoke(_scoreDatas.ScoreValue);
      point = 0;
      _audioEventDispatcher.Playaudio(_levelup);
    }
    else
    {
      OntargetCollected?.Invoke(_scoreDatas.ScoreValue);
    }
  }
}

