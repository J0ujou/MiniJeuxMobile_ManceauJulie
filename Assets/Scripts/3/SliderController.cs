using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] Slider slider;
    private float targetValue;

    public void UpdateProgress( int progress)
    {
        StartCoroutine(TransitionSlide(progress));
    }

    private IEnumerator TransitionSlide(int targetFill)
    {
        float originalFill = slider.value;
        float elapsedTime = 0.0f;

        while (elapsedTime < 0.25f)
        {
            elapsedTime += Time.deltaTime;
            float time = elapsedTime / 0.25f;
            slider.value = Mathf.Lerp(originalFill, targetFill, time);
            
            yield return null;
        }
    }
}
