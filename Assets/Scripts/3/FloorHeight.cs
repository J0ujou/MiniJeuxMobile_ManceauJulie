using System;
using UnityEngine;

public class FloorHeight : MonoBehaviour
{
    
    private float MaxHeight = -3.9f;
    
    public event Action MooveGround;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.transform.position.y > MaxHeight)
        {
            Debug.Log("KK");
            MooveGround ?.Invoke();
        }
    }
}
