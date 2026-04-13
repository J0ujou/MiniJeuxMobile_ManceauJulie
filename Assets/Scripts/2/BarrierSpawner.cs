using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _barrierObjects;
    [SerializeField] private GellySpawner _gellySpawner;
    [SerializeField] private CollectibleSpawner _collectibleSpawner;
    [SerializeField] private PlatformSpawner _platformSpawner;
    [SerializeField] public float _platformPauseDuration = 1f;
    [Header("Spawing Details")]
    [SerializeField] public float _maxSpawnInterval = 2f;
    [SerializeField] private float _minSpawnInterval = 0.7f;
    private float _spawnInterval = 5f;
    

    private float timer =0f;
    private float _pauseTimer = 0f;

    private void Start()
    {
        _maxSpawnInterval = 1.5f;
        _maxSpawnInterval= Mathf.Clamp(_maxSpawnInterval,_minSpawnInterval,_spawnInterval);
    }
    private void Update()
    {
        if (_pauseTimer > 0f)
        {
            _pauseTimer -= Time.deltaTime;
            return;
        }
        timer += Time.deltaTime;
        if (timer >= _spawnInterval)
        {
            timer = 0f;
            _spawnInterval= Random.Range(_minSpawnInterval, _maxSpawnInterval);
            //var fonctions = new System.Action[] { SpawnBarrier, _gellySpawner.SpawnGelly, _collectibleSpawner.SpawnCollectible };
            int rand = Random.Range(0, 100);
            if (rand < 50)
            {
                SpawnBarrier();
            }
            else if (rand < 80)
            {
                _gellySpawner.SpawnGelly();
            }
            else
            {
                _collectibleSpawner.SpawnCollectible();
            }
            //SpawnBarrier();
        }
    }
    
    public void Pause(float duration)
    {
        _pauseTimer = duration;
        timer = 0f;
    }
    
    private int RandomBarrier()
    {
        return Random.Range(0, _barrierObjects.Length);
    }
    public void SpawnBarrier()
    {
        Instantiate(_barrierObjects[RandomBarrier()], transform.position, Quaternion.identity);
        //_platformSpawner.Pause(_platformPauseDuration);
    }
}
