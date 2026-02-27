using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_ButtonEffect : MonoBehaviour
{
    [SerializeField] private GameObject HighScorePanel;
    [SerializeField] private AudioEventDispatcher _audioEventDispatcher;
    [SerializeField] private AudioType _button;
    [SerializeField] private AudioType _lock;

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

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LockButton()
    {
        _audioEventDispatcher.Playaudio(_lock);
    }

    public void ButtonSound()
    {
        _audioEventDispatcher.Playaudio(_button);
    }
}
