using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sweets : MonoBehaviour
{
    public int SweetIndex;
    public CharacterMovement characterMovement;
    public bool hasBeenDropped=false;

    public static event Action<int> GainPoints;

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
        hasBeenDropped = true;
        
        if (collision.gameObject.CompareTag("Sweet"))
        {
            Sweets collidedSweet =  collision.gameObject.GetComponent<Sweets>();
            
            if (collidedSweet.SweetIndex == SweetIndex)
            {
                if (SweetIndex == 11)
                {
                    return;
                }
                
                if(!gameObject.activeSelf || !collision.gameObject.activeSelf)
                    return;
                
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
                
                GameObject nextSweet = Instantiate(characterMovement.sweetsPrefabs[SweetIndex + 1].prefab); // a voir quand on fusionne deux pastèques pck la ca devient un malus
                GainPoints?.Invoke(characterMovement.sweetsPrefabs[SweetIndex + 1].points);
                nextSweet.transform.position = transform.position;
                
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    public void DeleteMalusSweet()
    {
        if (SweetIndex == 11)
        {

            Destroy(gameObject);
        }
    }
}
