using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Random = UnityEngine.Random;

public class GellyEffect : MonoBehaviour
{
    [SerializeField] private Sprite[] GellySprites;

    public static event Action DoGellyJump;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharaBehaviour>() != null)
        {
            DoGellyJump();
        }
    }
}
