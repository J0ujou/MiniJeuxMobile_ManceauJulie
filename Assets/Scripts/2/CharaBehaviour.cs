using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using TMPro;

public class CharaBehaviour : MonoBehaviour
{
    public bool IsAlive = true;
    private bool IsGrounded = false;
    
    [SerializeField] private Rigidbody2D CharaRigidbody;
    [SerializeField] private float _jumpHeight= 8f;
    [SerializeField] private float _rayLength = 1.0f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Animator charaAnimator;
    [SerializeField] private Animator JumpFXAnimator;
    [SerializeField] private GameScript gameScript;
    [SerializeField] private Shield shield;
    [SerializeField] TMP_Text _collectibleText;
    [SerializeField] private GameObject loosePanel;
    private int NbCollectible = 0;
    [SerializeField] private int NbForShield = 3;
    
    [SerializeField] private AudioEventDispatcher _audioEventDispatcher;
    [SerializeField] private AudioType _pickup;
    [SerializeField] private AudioType _bubble;
    [SerializeField] private AudioType _bubblePop;
    [SerializeField] private AudioType _jump;
    [SerializeField] private AudioType _gelly;
    

    public static event Action Shieldcreation;
    public static event Action OnShieldDestroy;
    
    private void Start()
    {
        Time.timeScale = 1.0f;
        IsAlive = true;
        NbCollectible = 0;
        
        CharaRigidbody= GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        GellyEffect.DoGellyJump += GellyJump;
        PlayerInput.jump += Jumping;
    }

    private void OnDisable()
    {
        GellyEffect.DoGellyJump -= GellyJump;
        PlayerInput.jump -= Jumping;
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
            if (shield.shielded)
            {
                OnShieldDestroy?.Invoke();
                Destroy(collision.gameObject);
                UpdateText();
                _audioEventDispatcher.Playaudio(_bubblePop);
            }
            else
            {
                Time.timeScale = 0.0f;
                IsAlive = false;
                charaAnimator.SetBool("IsDead", true);
                loosePanel.SetActive(true);
                gameScript.EndGame();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            NbCollectible++;
            UpdateText();
            if (NbCollectible >= NbForShield)
            {
                _audioEventDispatcher.Playaudio(_bubble);
                NbCollectible = 0;
                Shieldcreation?.Invoke();
            }
            _audioEventDispatcher.Playaudio(_pickup);
        }
    }

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        charaAnimator.SetBool("IsJumping", true);
        if (callbackContext.started && IsGrounded && IsAlive)
        {
            CharaRigidbody.linearVelocity = new Vector2(CharaRigidbody.linearVelocity.x, _jumpHeight);
            JumpFXAnimator.SetTrigger("Jumped");
            _audioEventDispatcher.Playaudio(_jump);
        }
    }
    
    public void Jumping()
    {
        charaAnimator.SetBool("IsJumping", true);
        if (IsGrounded && IsAlive)
        {
            CharaRigidbody.linearVelocity = new Vector2(CharaRigidbody.linearVelocity.x, _jumpHeight);
            JumpFXAnimator.SetTrigger("Jumped");
            _audioEventDispatcher.Playaudio(_jump);
        }
    }

    public void GellyJump()
    {
        charaAnimator.SetBool("IsJumping", true);
        if (IsAlive)
        {
            CharaRigidbody.linearVelocity = new Vector2(CharaRigidbody.linearVelocity.x, 14f);
            JumpFXAnimator.SetTrigger("Jumped");
            _audioEventDispatcher.Playaudio(_gelly);
        }
    }
    
    private void UpdateText()
    {
        _collectibleText.text = $"{NbCollectible.ToString()}/3";
    }
}
