 using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNamePanel : MonoBehaviour
{
    [SerializeField] private SO_PlayerDatas playerDatas;
    [SerializeField] private TMP_InputField playerInputField;

    private void Awake()
    {
        playerDatas.LoadDatas();
    }

    private void Start()
    {
        LoadDatasInPanel();
    }
    public void LoadDatasInPanel()
    {
        playerInputField.text = playerDatas.Name;
    }

    public void SaveDatasInSO()
    {
        playerDatas.Name = playerInputField.text;
        playerDatas.SaveDatas();
    }
}
