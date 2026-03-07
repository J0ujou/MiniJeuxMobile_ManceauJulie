using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sweets : MonoBehaviour
{
    public GameObject[] sweetsPrefabs;
    public int SweetIndex;
    public CharacterMovement characterMovement;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sweet"))
        {
            Sweets collidedSweet =  collision.gameObject.GetComponent<Sweets>();
            
            if (collidedSweet.SweetIndex == SweetIndex)
            {
                if(!gameObject.activeSelf || !collision.gameObject.activeSelf)
                    return;
                
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
                
                Debug.Log("Sweet");
                GameObject nextSweet = Instantiate(sweetsPrefabs[SweetIndex + 1]);
                nextSweet.transform.position = transform.position;
                
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
