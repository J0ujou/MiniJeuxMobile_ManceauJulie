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
        if (UI_Panel.AlreadyPlayed)
        {
            this.gameObject.SetActive(false);
        }
    }
}
