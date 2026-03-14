using System;
using UnityEngine;

public class FloorHeight : MonoBehaviour
{
    
    private float MaxHeight = 0.5f;
    [SerializeField] Animator PoofAnimator;
    
    public event Action MooveGround;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            PoofAnimator.SetTrigger("Jumped");
            if (this.gameObject.transform.position.y > MaxHeight)
            {
                MooveGround ?.Invoke();
            }
            
        }
    }
}
