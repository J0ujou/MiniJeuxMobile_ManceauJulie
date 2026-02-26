using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_ButtonEffect : MonoBehaviour
{
    [SerializeField] private GameObject HighScorePanel;

    public void ActiveHighScorePanel()
    {
        HighScorePanel.SetActive(true);
    }

    public void DisableHighScorePanel()
    {
        HighScorePanel.SetActive(false);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenGameNWatch()
    {
        SceneManager.LoadScene(1);
    }
}
