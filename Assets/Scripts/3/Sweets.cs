using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sweets : MonoBehaviour
{
    public int SweetIndex;
    public CharacterMovement characterMovement;
    public bool hasBeenDropped = false;
    [SerializeField] Animator FusionFXAnimator;

    private SpriteRenderer sprite;
    private Collider2D coll;
    private Rigidbody2D rb;

    public static event Action<int> GainPoints;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        UIScoreSuika.DeleteMalus += DeleteMalusSweet;
    }

    private void OnDisable()
    {
        UIScoreSuika.DeleteMalus -= DeleteMalusSweet;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            hasBeenDropped = true;
        }

        if (collision.gameObject.CompareTag("Sweet"))
        {
            hasBeenDropped = true;
            Sweets collidedSweet = collision.gameObject.GetComponent<Sweets>();

            if (collidedSweet.SweetIndex == SweetIndex)
            {
                if (SweetIndex == 11)
                {
                    return;
                }

                if (!gameObject.activeSelf || !collision.gameObject.activeSelf)
                    return;
                
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);

                GameObject
                    nextSweet = Instantiate(characterMovement.sweetsPrefabs[SweetIndex + 1]
                        .prefab); // a voir quand on fusionne deux pastèques pck la ca devient un malus
                GainPoints?.Invoke(characterMovement.sweetsPrefabs[SweetIndex + 1].points);
                nextSweet.transform.position = transform.position;
                
                StartCoroutine(BeforeDestroy());
            }
        }
    }

    public void DeleteMalusSweet()
    {
        if (SweetIndex == 11)
        {

            StartCoroutine(BeforeDestroy());
        }
    }


    IEnumerator BeforeDestroy()
    {
        FusionFXAnimator.SetTrigger("Fusion");
        sprite.enabled = false;
        //coll.isTrigger = true;
        //rb.isKinematic = true;
        
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

}