using System;
using TMPro;
using UnityEngine;

public class UI_Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private PlayerCollect playerCollect;
    [SerializeField] private ScoreDatas _scoreData;

    private void OnEnable()
    {
        PlayerCollect.OnLevelUp += UpdateLevel;
        PlayerCollect.OntargetCollected += UpdateScore;
    }

    private void OnDisable()
    {
        PlayerCollect.OnLevelUp -= UpdateLevel;
        PlayerCollect.OntargetCollected -= UpdateScore;
    }

    private void Start()
    {
        //UpdateLevel(1);
        UpdateScore(0);
        //_scoreData.Level =1;
        _scoreData.ScoreValue = 0;
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = $"Score : {score.ToString()}";
    }

    public void UpdateLevel(int level)
    {
        _levelText.text = $"Level : {level.ToString()}";
    }
}
