using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;


public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float minXposition = -2.6f;
    [SerializeField] private float maxXposition = 2.6f;
    
    private float currentMinXposition = -2.6f;
    private float currentMaxXposition = 2.6f;
    
    [SerializeField] public SweetsList[] sweetsPrefabs;
    
    private GameObject nextSweet;
    private int nextSweetIndex;
    private GameObject NextnextSweet;
    private int NextnextSweetIndex;

    private bool Wait = true;
    
    public static event Action<Sprite> OnNextnextSweetChanged;

    [SerializeField] private float sideGapForBiggerSweet =0.07f;
    private float defaultYPosition = 3.78f;

    private void Start()
    {
        LoadNextSweet();
    }
    
    private void Update()
    {
        
        if (Input.anyKey)
        {
            Debug.Log("Une touche est pressée");
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > currentMinXposition)
        {
            Debug.Log("kk");
            transform.position -= new Vector3(5 * Time.deltaTime, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < currentMaxXposition)
        {
            transform.position += new Vector3(5 * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Wait == true)
            {
                Wait = false;
                GameObject newSweet = Instantiate(nextSweet);
                newSweet.transform.position = transform.position;

                Sweets newSweetScript = newSweet.GetComponent<Sweets>();
                newSweetScript.characterMovement = this;
                newSweetScript.SweetIndex = nextSweetIndex;

                LoadNextSweet();
                StartCoroutine(Cooldown());
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        Wait = true;
    }

    private void LoadNextSweet()
    {
            //Next
            if (NextnextSweetIndex != null)
            {
                int[] values = { 0, 1, 2, 3, 4, 11 };
                nextSweetIndex = values[Random.Range(0, values.Length)];
                nextSweet = sweetsPrefabs[nextSweetIndex].prefab;
            
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }

                GameObject nextSweetPreview = Instantiate(nextSweet, transform);
                nextSweetPreview.GetComponent<Collider2D>().isTrigger = true;
                nextSweetPreview.GetComponent<Rigidbody2D>().isKinematic = true;
                nextSweetPreview.transform.localPosition = Vector3.zero;
            }
            else
            {
                 nextSweet = NextnextSweet;
            }
            
            //NextNext
            NextnextSweetIndex = Random.Range(0, 5);
            NextnextSweet = sweetsPrefabs[NextnextSweetIndex].prefab;
            
            Sprite NextnextSprite = NextnextSweet.GetComponent<SpriteRenderer>().sprite;
            OnNextnextSweetChanged?.Invoke(NextnextSprite);
            
            //GameObject NextnextSweetPreview = Instantiate(NextnextSweet, transform);
            //NextnextSweetPreview.GetComponent<Collider2D>().isTrigger = true;
            //NextnextSweetPreview.GetComponent<Rigidbody2D>().isKinematic = true;
            //NextnextSweetPreview.transform.localPosition = Vector3.zero;
            
           CalculateCharaBounds();

    }
    
    private void CalculateCharaBounds()
    { 
        currentMinXposition = minXposition + (nextSweetIndex* sideGapForBiggerSweet);
        currentMaxXposition = maxXposition - (nextSweetIndex * sideGapForBiggerSweet);

        if (transform.position.x < currentMinXposition)
        {
            transform.position = new Vector3(currentMinXposition, defaultYPosition, 0);
        }
        else if (transform.position.x > currentMaxXposition)
        {
            transform.position = new Vector3(currentMaxXposition, defaultYPosition, 0);
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

[System.Serializable]
public class SweetsList
{
    public GameObject prefab;
    public int points;
}
