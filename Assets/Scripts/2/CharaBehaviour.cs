using UnityEngine;
using UnityEngine.InputSystem;

public class CharaBehaviour : MonoBehaviour
{
    public bool IsAlive = true;
    private bool IsGrounded = false;
    
    [SerializeField] private Rigidbody2D CharaRigidbody;
    [SerializeField] private float _jumpHeight= 8f;
    [SerializeField] private float _rayLength = 1.0f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Animator charaAnimator;
    [SerializeField] private GameScript gameScript;

    private void Start()
    {
        Time.timeScale = 1.0f;
        IsAlive = true;
        
        CharaRigidbody= GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D playerRaycast = Physics2D.Raycast(transform.position, Vector2.down, _rayLength, _groundLayer);
        IsGrounded = playerRaycast.collider != null;
        charaAnimator.SetBool("StartedGame", true);
        if (IsGrounded)
        {
            charaAnimator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Time.timeScale = 0.0f;
            IsAlive = false;
            charaAnimator.SetBool("IsDead", true);
            gameScript.EndGame();
        }
    }

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        charaAnimator.SetBool("IsJumping", true);
        if (callbackContext.started && IsGrounded && IsAlive)
        {
            CharaRigidbody.linearVelocity = new Vector2(CharaRigidbody.linearVelocity.x, _jumpHeight);
        }
    }
}
