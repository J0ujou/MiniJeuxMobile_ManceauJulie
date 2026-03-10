using System;
using System.Collections;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_ButtonEffect : MonoBehaviour
{
    [SerializeField] private GameObject HighScorePanel;
    [SerializeField] private AudioEventDispatcher _audioEventDispatcher;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioType _button;
    [SerializeField] private AudioType _lock;
    [SerializeField] private Animator _Lock1animator;
    [SerializeField] private Animator _Lock2animator;
    [SerializeField] private Button RNJ;
    [SerializeField] private Button SG;
    [SerializeField] private Animator uiPresentationAnimator;
    
    public event Action Tutorial;


    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (UI_Panel.AlreadyPlayed)
            {
                RNJ.onClick.RemoveListener(Lock1);
                RNJ.onClick.RemoveListener(LockButton);
                RNJ.onClick.AddListener(ButtonSound);
                RNJ.onClick.AddListener(OpenRunNJump);
            }

            if (UI_Panel.AlreadyPlayed && GameScript.AlreadyPlayed)
            {
                SG.onClick.RemoveListener(Lock2);
                SG.onClick.RemoveListener(LockButton);
                SG.onClick.AddListener(ButtonSound);
                SG.onClick.AddListener(OpenSuikaGame);
            }
        }
    }
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

    public void OpenRunNJump()
    {
        if (UI_Panel.AlreadyPlayed)
        {
            _audioSource.Stop();
            SceneManager.LoadScene(2);
        }
    }

    public void OpenSuikaGame()
    {
        if (GameScript.AlreadyPlayed && UI_Panel.AlreadyPlayed)
        {
            _audioSource.Stop();
            SceneManager.LoadScene(3);
        }
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

    public void Play()
    {
        uiPresentationAnimator.SetTrigger("PlayPressed");
        StartCoroutine(TapWait());
    }

    IEnumerator TapWait()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        if (GameScript.AlreadyPlayed)
        {
            Time.timeScale = 1;
        }
        else
        {
            Tutorial?.Invoke();
        }
        
    }
}
