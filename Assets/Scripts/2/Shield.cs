using System;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool shielded = false;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        CharaBehaviour.Shieldcreation += ShieldCreation;
        CharaBehaviour.OnShieldDestroy += ShieldDestroy;
    }

    private void OnDisable()
    {
        CharaBehaviour .Shieldcreation -= ShieldCreation;
        CharaBehaviour.OnShieldDestroy -= ShieldDestroy;
    }

    private void Start()
    {
        spriteRenderer.enabled = false;
        shielded = false;
    }

    public void ShieldCreation()
    {
        spriteRenderer.enabled = true;
        shielded = true;
    }

    public void ShieldDestroy()
    {
        spriteRenderer.enabled = false;
        shielded = false;
    }
}
