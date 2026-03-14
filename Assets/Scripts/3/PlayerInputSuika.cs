using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerInputSuika : MonoBehaviour
{
  [SerializeField] private float  _tapDuration = 0.09f;
  private float _tapTimer = 0.0f;
  private bool _isTouching = false;
  private float width = 0.0f;
  private float height = 0.0f;
  
  [SerializeField] private AudioEventDispatcher _audioEventDispatcher;
  [SerializeField] private AudioType _drop;
  
  private Vector2 startPosition;
  private Vector2 endPosition;
  
  public event Action OnMoveLeft;
  public event Action OnMoveRight;
  public event Action OnDropSweet;
  private void Start()
  {
    width = Screen.width;
    height = Screen.height;
    UnityEngine.InputSystem.EnhancedTouch.EnhancedTouchSupport.Enable();
  }


  private void OnDisable()
  {
    UnityEngine.InputSystem.EnhancedTouch.EnhancedTouchSupport.Disable();
  }
  
  private void Update()
  {
    if (Touch.activeTouches.Count <= 0 || Time.timeScale == 0f)
    {
      return;
    }
    
    Touch touch = Touch.activeTouches[0];
    if (touch.phase == TouchPhase.Began)
    {
      startPosition = touch.screenPosition;
      _isTouching = true;
    }
    else if (touch.phase == TouchPhase.Moved)
    {
      endPosition = touch.screenPosition;
      OnSwipe();
    }
    else if (touch.phase == TouchPhase.Ended)
    {
      endPosition = touch.screenPosition;
      _isTouching = false;
      if (_tapTimer < _tapDuration)
      {
        _audioEventDispatcher.Playaudio(_drop);
        OnDropSweet?.Invoke();
      }
      _tapTimer = 0.0f;
    }

    if (_isTouching)
    {
      _tapTimer += Time.deltaTime;
    }
  }

  
  private float minSwipeDistance = 5f;
  public void OnSwipe()
  {
    Vector2 delta = endPosition - startPosition;
    if (delta.magnitude < minSwipeDistance)
    {
      return;
    }
    delta = delta.normalized;
    float dot = Vector2.Dot(delta, Vector2.right);

    if (Mathf.Abs(dot) > 0.5f)
    {
      if (dot < 0.0f)
      {
        OnMoveLeft?.Invoke();
      }
      else
      {
        OnMoveRight?.Invoke();
      }
    }
    startPosition = endPosition;
  }
}

