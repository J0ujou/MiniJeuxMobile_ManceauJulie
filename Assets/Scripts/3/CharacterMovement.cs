using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float minXposition = -2.6f;
    [SerializeField] private float maxXposition = 2.6f;
    
    [SerializeField] public GameObject[] sweetsPrefabs;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > minXposition)
        {
            transform.position -= new Vector3(5* Time.deltaTime,0f,0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < maxXposition)
        {
            transform.position += new Vector3(5* Time.deltaTime,0f,0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int randomSweetIndex = Random.Range(0, 5);
            
            GameObject newSweet = Instantiate(sweetsPrefabs[randomSweetIndex]);
            newSweet.transform.position = transform.position;
            
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            Sweets newSweetScript= newSweet.GetComponent<Sweets>();
            newSweetScript.SweetIndex = randomSweetIndex;
        }
    }

     public void MoveLimits()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > minXposition)
        {
            transform.position -= new Vector3(5* Time.deltaTime,0f,0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < maxXposition)
        {
            transform.position += new Vector3(5* Time.deltaTime,0f,0f);
        }
    }
}
