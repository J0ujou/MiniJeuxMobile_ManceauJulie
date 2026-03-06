using TMPro;
using UnityEngine;

public class GameScript : MonoBehaviour
{
   [SerializeField] private CharaBehaviour _charaBehaviour;
   [SerializeField] TMP_Text _scoreText;
   [SerializeField] private SO_PlayerDatas playerDatas;
   [SerializeField] private string gameName = "RunNJump";
   [SerializeField] private GameObject highscorePanel;
   [SerializeField] private TMP_Text highscoreText;
   [SerializeField] private TMP_Text scoreText;
   [SerializeField] private GameObject loosePanel;
   [SerializeField] public Animator uiCandyRainGameOverAnimator;

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
        //_audioEventDispatcher.Playaudio(_death);
        loosePanel.SetActive(true);
        //SaveScore?.Invoke();
        uiCandyRainGameOverAnimator.SetTrigger("Loose");
            if (playerDatas.IsBestScore(gameName, playerScore))
            {
                highscoreText.gameObject.SetActive(true);
                //_audioSource.PlayOneShot(_newReccordClip);
            }
            if (playerDatas.IsHighscore(gameName, playerScore))
            {
                playerDatas.AddHighscore(gameName, playerDatas.Name, playerScore);
            }
            scoreText.text = $"Score: {playerScore.ToString()}";
    }
}
