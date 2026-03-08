using UnityEngine;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerInput : MonoBehaviour
{
  [SerializeField] private float _tapDuration = 1.0f;
  private float _tapTimer = 0.0f;
  private bool _isTouching = false;
  private float width = 0.0f;
  private float height = 0.0f;

  private Vector2 startPosition;
  private Vector2 endPosition;

  public static event Action jump;

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

    if (Input.touchCount > 0)
    {
      UnityEngine.Touch firstTouch = Input.GetTouch(0);

      if (firstTouch.phase == (UnityEngine.TouchPhase)TouchPhase.Began)
      {
        _isTouching = true;
        if (_tapTimer <= _tapDuration)
        {
          jump?.Invoke();
        }
      }
      else if (firstTouch.phase == (UnityEngine.TouchPhase)TouchPhase.Ended)
      {
        _isTouching = false;

      }
    }
  }
}
