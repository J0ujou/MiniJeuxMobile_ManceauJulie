using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameScript : MonoBehaviour
{
   [SerializeField] private CharaBehaviour _charaBehaviour;
   [SerializeField] TMP_Text _scoreText;
   [SerializeField] private SO_PlayerDatas playerDatas;
   [SerializeField] private ScoreDatas scoreDatas;
   [SerializeField] private string gameName = "RunNJump";
   [SerializeField] private GameObject highscorePanel;
   [SerializeField] private TMP_Text highscoreText;
   [SerializeField] private TMP_Text scoreText;
   [SerializeField] public Animator uiCandyRainGameOverAnimator;
   //[SerializeField] public BarrierBehaviour[] barrierBehaviour;
   [SerializeField] private int ScoreToLevelUp = 20;
   private int ScorePerLevel;

    private int playerScore = 0;
    private float scoreTimer = 0f;

    private void Start()
    {
        ScorePerLevel = 0;
        playerScore = 0;
    }

    private void Awake()
    {
        //playerDatas.LoadDatas();
    }

    private void Update()
    {
        
        scoreTimer += Time.deltaTime;
        
        //ajouter 1 point tte les secondes
        if (scoreTimer >= 1f)
        {
            if (ScorePerLevel >= ScoreToLevelUp)
            {
                ScorePerLevel = 0;
                LevelUpSpeed();
                Debug.Log("Level Up Speed");
            }
            else
            {
                ScorePerLevel++;
            }
            Debug.Log(ScorePerLevel);
            playerScore += 1;

            scoreTimer = 0f;
            UpdateScoreText();
        }
        
    }

    private void LevelUpSpeed()
    {
        //for (int i = 0; i < barrierBehaviour.Length; i++)
        //{
            //barrierBehaviour[i]._barrierMovementSpeed = barrierBehaviour[i]._barrierMovementSpeed + 10;
        //}
        scoreDatas.BarrierSpeed += 2;
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"Score : {playerScore.ToString()}";
    }

    public void EndGame()
    {
        Debug.Log("EndGame");
        //_audioEventDispatcher.Playaudio(_death);
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
            highscorePanel.SetActive(true);
    }
}
