using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_ButtonEffect : MonoBehaviour
{
    [SerializeField] private GameObject HighScorePanel;
    [SerializeField] private AudioEventDispatcher _audioEventDispatcher;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioType _button;
    [SerializeField] private AudioType _lock;
    [SerializeField] private Animator _Lock1animator;
    [SerializeField] private Animator _Lock2animator;

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
        _audioSource.Stop();
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

    public void Lock1()
    {
        _Lock1animator.SetTrigger("ButtonPressed");
    }

    public void Lock2()
    {
        _Lock2animator.SetTrigger("Button2Pressed");
    }
}
