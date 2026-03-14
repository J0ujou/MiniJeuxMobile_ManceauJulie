using System;
using UnityEngine;

public class FloorHeight : MonoBehaviour
{
    
    private float MaxHeight = 0.5f;
    [SerializeField] Animator PoofAnimator;
    [SerializeField] private AudioEventDispatcher _audioEventDispatcher;
    [SerializeField] private AudioType _drop;
    
    public event Action MooveGround;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            _audioEventDispatcher.Playaudio(_drop);
            PoofAnimator.SetTrigger("Jumped");
            if (this.gameObject.transform.position.y > MaxHeight)
            {
                MooveGround ?.Invoke();
            }
            
        }
    }
}
