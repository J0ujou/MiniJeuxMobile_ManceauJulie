using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (!UIScoreSuika.AlreadyPlayed && SceneManager.GetActiveScene().buildIndex == 3)
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
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            playerInputSuika.Tutorial += StartTutorialSuika;
        }
    }

    private void OnDisable()
    {
        uiButtonEffect.Tutorial -= StartTutorial;
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            playerInputSuika.Tutorial -= StartTutorialSuika;
        }
    }

    /*IEnumerator TutoSuika()
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
    }*/
    
    IEnumerator Step(
        int arrowIndexToEnable = -1,
        string boolName = "",
        int arrowIndexToDisable = -1,
        string boolDisableName = "",
        bool textZone1 = true,
        bool textZone2 = false)
    {
        tutoIndex++;

        // Texte
        TutoTexts[tutoIndex - 1].SetActive(false);
        TutoTexts[tutoIndex].SetActive(true);

        // Flèches ON
        if (arrowIndexToEnable != -1)
            ArrowAnimator2[arrowIndexToEnable].SetBool(boolName, true);

        // Flèches OFF
        if (arrowIndexToDisable != -1)
            ArrowAnimator2[arrowIndexToDisable].SetBool(boolDisableName, false);

        // Zones texte
        Textzone.SetActive(textZone1);
        Textzone2.SetActive(textZone2);
        
        yield return StartCoroutine(WaitTutorial2());
    }
    
    IEnumerator TutoSuika()
    {
        ArrowAnimator2[1].SetBool("Tuto5", false);
        yield return Step(2, "Tuto2", 0, "Tuto4");
        yield return Step();
        yield return Step(4, "Tuto6", 2, "Tuto2", false, true);
        yield return Step(3, "Tuto3", 4, "Tuto6", true, false);
        yield return Step(4, "Tuto6", 3, "Tuto3", false, true);

        yield return StartCoroutine(WaitTutorial2());

        ArrowAnimator2[4].SetBool("Tuto6", false);
        TutoTexts[tutoIndex].SetActive(false);
        Textzone2.SetActive(false);

        //Time.timeScale = 1;
    }
    IEnumerator WaitTutorial2()
    {
        yield return new WaitForSecondsRealtime(5f);
    }

    private void StartTutorialSuika()
    {
        StartCoroutine(TutoSuika());
    }
    
    /// <summary>
    /// vieux scripts que j'ai rassemblé en un
    /// </summary>

    /*private void Tuto()
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
        //yield return new WaitForSecondsRealtime(5f);
        yield return StartCoroutine(WaitPausable(5f));
        TutoTexts[tutoIndex-1].SetActive(false);
        Textzone.SetActive(false);
        ArrowAnimator.SetBool("Tuto?", false);
        Time.timeScale = 1;
    }

    IEnumerator WaitTutorial()
    {
        yield return StartCoroutine(WaitPausable(2f));
        // return new WaitForSeconds(2f);
    }*/
    
    // IEnumerator TutoComplet()
    // {
    //     Tuto();
    //      yield return StartCoroutine(WaitTutorial());
    //     Tuto();
    //      yield return StartCoroutine(WaitTutorial());
    //     Tuto();
    // }

    private void StartTutorial()
    {
        StartCoroutine(TutoComplet());
    }
    
    IEnumerator TutoComplet()
    {
        const float displayDuration = 5f;
        const float pauseBetweenSteps = 2f;
        const int stepCount = 3;

        for (int i = 0; i < stepCount; i++)
        {
            uiButtonEffect._tutoActivate = true;
            Time.timeScale = 0f;
            ArrowAnimator.SetBool("Tuto?", true);
            Textzone.SetActive(true);
            TutoTexts[tutoIndex].SetActive(true);

            yield return StartCoroutine(WaitPausable(displayDuration));

            TutoTexts[tutoIndex].SetActive(false);
            tutoIndex++;
            Textzone.SetActive(false);
            ArrowAnimator.SetBool("Tuto?", false);
            Time.timeScale = 1f;
            uiButtonEffect._tutoActivate = false;

            if (i < stepCount - 1)
                yield return new WaitForSeconds(pauseBetweenSteps);
        }
    }
    
    private IEnumerator WaitPausable(float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            //elapsed += Time.unscaledDeltaTime;
            if (uiButtonEffect.isPaused == false)
            {
               elapsed += Time.unscaledDeltaTime;
            }
            yield return null;
        }
    }
}
