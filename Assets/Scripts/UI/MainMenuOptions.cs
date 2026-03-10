using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MainMenuOptions : MonoBehaviour
{
    
    [SerializeField] private GameObject _Lock1;
    [SerializeField] private GameObject _Lock2;
    [SerializeField] private GameObject RNJ;
    [SerializeField] private GameObject SG;
    private void Start()
    {
        suppr();
        Image image = RNJ.GetComponent<Image>();
        Image image2 = SG.GetComponent<Image>();
        
        if (UI_Panel.AlreadyPlayed)
        {
            _Lock1.SetActive(false);
            image.color= Color.white;

        }

        if (UI_Panel.AlreadyPlayed && GameScript.AlreadyPlayed)
        {
            _Lock2.SetActive(false);
            image2.color= Color.white;

        }
    }
    public void suppr()
    {
        if (UI_Panel.AlreadyPlayed || GameScript.AlreadyPlayed)
        {
            this.gameObject.SetActive(false);
        }
    }
}
