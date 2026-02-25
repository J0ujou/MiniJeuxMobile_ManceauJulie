using TMPro;
using UnityEngine;

public class GameScript : MonoBehaviour
{
   [SerializeField] private CharaBehaviour _charaBehaviour;
   [SerializeField] TMP_Text _scoreText;
   [SerializeField] private SO_PlayerDatas playerDatas;
   [SerializeField] private string gameName = "RunNJump";
   [SerializeField] private GameObject highscorePanel;

    private int playerScore = 0;
    private float scoreTimer = 0f;

    private void Awake()
    {
        playerDatas.LoadDatas();
    }

    private void Update()
    {
        
        scoreTimer += Time.deltaTime;
        
        //ajouter 1 point tte les secondes
        if (scoreTimer >= 1f)
        {
            playerScore += 1;
            scoreTimer = 0f;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"Score : {playerScore.ToString()}";
    }

    public void EndGame()
    {
        if (playerDatas.IsHighscore(gameName, playerScore))
        {
            playerDatas.AddHighscore(gameName, playerDatas.Name, playerScore);
        }
        if (highscorePanel != null)
        {
            highscorePanel.SetActive(true);
        }
    }
}
