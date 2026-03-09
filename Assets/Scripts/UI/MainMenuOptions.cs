using UnityEngine;
using UnityEngine.Rendering;

public class MainMenuOptions : MonoBehaviour
{
    private void Start()
    {
        suppr();
    }
    public void suppr()
    {
        if (UI_Panel.AlreadyPlayed || GameScript.AlreadyPlayed)
        {
            this.gameObject.SetActive(false);
        }
    }
}
