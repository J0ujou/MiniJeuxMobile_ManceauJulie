using UnityEngine;
using System;
using TMPro;

public class ShieldCollectibles : MonoBehaviour
{
    private int NbCollectible;
    [SerializeField] private int NbForShield = 3;
    [SerializeField] Shield shield;

    public static event Action Shieldcreation;
    private void Start()
    {
        NbCollectible = 0;
    }

    private void Update()
    {
        if (NbCollectible >= NbForShield)
        {
            if (!shield.shielded)
            {
                Shieldcreation?.Invoke();
            }
            NbCollectible = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NbCollectible++;
            Destroy(gameObject);
        }
    }
}
