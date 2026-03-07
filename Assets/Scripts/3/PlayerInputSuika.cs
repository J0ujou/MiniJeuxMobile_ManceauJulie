using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerInputSuika : MonoBehaviour
{
  [SerializeField] private float  _tapDuration = 1.0f;
  private float _tapTimer = 0.0f;
  private bool _isTouching = false;
  private float width = 0.0f;
  private float height = 0.0f;
  
  private Vector2 startPosition;
  private Vector2 endPosition;
  private bool swipedetected = false;
  
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
    if (Touch.activeTouches.Count <= 0)
    {
      return;
    }
    
    Touch touch = Touch.activeTouches[0];
    if (touch.phase == TouchPhase.Began)
    {
      startPosition = touch.screenPosition;
      swipedetected = false;
      OnDropSweet?.Invoke();
    }
    else if (touch.phase == TouchPhase.Moved)
    {
      endPosition = touch.screenPosition;
      OnSwipe();
    }
    else if (touch.phase == TouchPhase.Ended && !swipedetected)
    {
      endPosition = touch.screenPosition;
      _isTouching = false;
    }

    if (_isTouching)
    {
      _tapTimer += Time.deltaTime;
    }
  }

  public void OnSwipe()
  {
    Vector2 delta = endPosition - startPosition;
    delta = delta.normalized;
               
    float dot = Vector2.Dot(delta, Vector2.right);

    if (Mathf.Abs(dot) > 0.7f)
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
  }
}

