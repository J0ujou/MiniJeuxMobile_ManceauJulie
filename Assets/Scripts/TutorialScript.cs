using System.Collections;
using TMPro;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private UI_ButtonEffect uiButtonEffect;
    [SerializeField] private GameObject Textzone;
    [SerializeField] private GameObject Textzone2;
    [SerializeField] private GameObject[] TutoTexts;
    [SerializeField] private Animator ArrowAnimator;
    [SerializeField] private Animator[] ArrowAnimator2;
    [SerializeField] private PlayerInputSuika playerInputSuika;
    private int tutoIndex = 0;

    private void Start()
    {
        tutoIndex = 0;
        if (!UIScoreSuika.AlreadyPlayed)
        {
            ArrowAnimator2[0].SetBool("Tuto4", true);
            ArrowAnimator2[1].SetBool("Tuto5", true);
            Textzone.SetActive(true);
            TutoTexts[tutoIndex].SetActive(true);
        }
    }

    private void OnEnable()
    {
        uiButtonEffect.Tutorial += StartTutorial;
        playerInputSuika.Tutorial += StartTutorialSuika;
    }

    private void OnDisable()
    {
        uiButtonEffect.Tutorial -= StartTutorial;
        playerInputSuika.Tutorial -= StartTutorialSuika;
    }

    IEnumerator TutoSuika()
    {
        yield return StartCoroutine(WaitTutorial2());
        tutoIndex++;
        //Time.timeScale = 0;
        ArrowAnimator2[0].SetBool("Tuto4", false);
        ArrowAnimator2[1].SetBool("Tuto5", false);
        TutoTexts[tutoIndex -1 ].SetActive(false);
        TutoTexts[tutoIndex].SetActive(true);
        ArrowAnimator2[2].SetBool("Tuto2", true);
        yield return StartCoroutine(WaitTutorial2());
        
        tutoIndex++;
        TutoTexts[tutoIndex -1 ].SetActive(false);
        TutoTexts[tutoIndex].SetActive(true);
        yield return StartCoroutine(WaitTutorial2());
        
        tutoIndex++;
        ArrowAnimator2[2].SetBool("Tuto2", false);
        Textzone2.SetActive(true);
        Textzone.SetActive(false);
        TutoTexts[tutoIndex -1 ].SetActive(false);
        TutoTexts[tutoIndex].SetActive(true);
        ArrowAnimator2[4].SetBool("Tuto6", true);
        yield return StartCoroutine(WaitTutorial2());
        
        tutoIndex++;
        ArrowAnimator2[4].SetBool("Tuto6", false);
        Textzone.SetActive(true);
        Textzone2.SetActive(false);
        TutoTexts[tutoIndex -1 ].SetActive(false);
        TutoTexts[tutoIndex].SetActive(true);
        ArrowAnimator2[3].SetBool("Tuto3", true);
        yield return StartCoroutine(WaitTutorial2());
        
        tutoIndex++;
        ArrowAnimator2[3].SetBool("Tuto3", false);
        Textzone2.SetActive(true);
        Textzone.SetActive(false);
        TutoTexts[tutoIndex -1 ].SetActive(false);
        TutoTexts[tutoIndex].SetActive(true);
        ArrowAnimator2[4].SetBool("Tuto6", true);
        yield return StartCoroutine(WaitTutorial2());
        
        ArrowAnimator2[4].SetBool("Tuto6", false);
        TutoTexts[tutoIndex].SetActive(false);
        Textzone2.SetActive(false);
        Time.timeScale = 1;
    }
    IEnumerator WaitTutorial2()
    {
        yield return new WaitForSecondsRealtime(5f);
    }

    private void StartTutorialSuika()
    {
        StartCoroutine(TutoSuika());
    }

    private void Tuto()
    {
        Time.timeScale = 0;
        ArrowAnimator.SetBool("Tuto?", true);
        Textzone.SetActive(true);
        TutoTexts[tutoIndex].SetActive(true);
        tutoIndex++;
        StartCoroutine(Tutorial());
    }

    IEnumerator Tutorial()
    {
        yield return new WaitForSecondsRealtime(5f);
        TutoTexts[tutoIndex-1].SetActive(false);
        Textzone.SetActive(false);
        ArrowAnimator.SetBool("Tuto?", false);
        Time.timeScale = 1;
    }

    IEnumerator WaitTutorial()
    {
        yield return new WaitForSeconds(2f);
    }

    private void StartTutorial()
    {
        StartCoroutine(TutoComplet());
    }
    IEnumerator TutoComplet()
    {
        Tuto();
         yield return StartCoroutine(WaitTutorial());
        Tuto();
         yield return StartCoroutine(WaitTutorial());
        Tuto();
    }
}
