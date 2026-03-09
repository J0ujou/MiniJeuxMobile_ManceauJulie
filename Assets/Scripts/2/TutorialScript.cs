using System.Collections;
using TMPro;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private UI_ButtonEffect uiButtonEffect;
    [SerializeField] private GameObject Textzone;
    [SerializeField] private TMP_Text BarrierText;
    [SerializeField] private TMP_Text ShieldText;
    [SerializeField] private TMP_Text GellyText;
    [SerializeField] private GameObject[] TutoTexts;
    [SerializeField] private Animator ArrowAnimator;
    private int tutoIndex = 0;

    private void Start()
    {
        tutoIndex = 0;
        ArrowAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    private void OnEnable()
    {
        uiButtonEffect.Tutorial += StartTutorial;
    }

    private void OnDisable()
    {
        uiButtonEffect.Tutorial -= StartTutorial;
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
