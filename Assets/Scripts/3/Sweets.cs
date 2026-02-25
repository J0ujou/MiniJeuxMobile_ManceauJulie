using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sweets : MonoBehaviour
{
    public GameObject[] sweetsPrefabs;
    public int SweetIndex;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sweet"))
        {
            Sweets collidedSweet =  collision.gameObject.GetComponent<Sweets>();
            
            if (collidedSweet.SweetIndex == SweetIndex)
            {
                Debug.Log("Sweet");
                GameObject nextSweet = Instantiate(sweetsPrefabs[SweetIndex + 1]);
                nextSweet.transform.position = transform.position;
                Destroy(gameObject);
                Destroy(collidedSweet.gameObject);
            }
        }
    }
}
