 using System;
 using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _transforms;
    private int _index = -1;
    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private GameObject _objectfalling;
    [SerializeField] private AudioEventDispatcher _audioEventDispatcher;
    [SerializeField] private AudioType _objectmovement;
    [SerializeField] private AudioType _destruction;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _destructionClip;
    
    
    public static event Action Loose;
    public void Init(GameObject NewObject)
    {
        if (_objectfalling != null)
        {
            Destroy(NewObject);
        }
        if (_objectfalling == null)
        {
            _objectfalling = NewObject;
            _index = 0;
            MoveObject();
            //_objectfalling.transform.position = _transforms[-1].position;
            _audioEventDispatcher.Playaudio(_objectmovement);
        }
    }

    private void OnEnable()
    {
        _timeManager.OnTimePassed += MoveObject;
    }
    
    private void OnDisable()
    {
        _timeManager.OnTimePassed -= MoveObject;
    }

    private void MoveObject()
    {
        if (_objectfalling == null)
        {
            return;
        }
        _index++;
        if (_index < _transforms.Length)
        {
            _objectfalling.transform.position = _transforms[_index].position;
            _audioEventDispatcher.Playaudio(_objectmovement);
        }
        else
        {
            Destroy(_objectfalling);
            _index = 0;
            Loose?.Invoke();
            _audioSource.PlayOneShot(_destructionClip);
        }
    }
}
