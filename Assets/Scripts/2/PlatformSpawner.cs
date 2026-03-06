using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _platformObjects;
    
    [SerializeField] private float _maxSpawnInterval = 4f;
    [SerializeField] private float _minSpawnInterval = 4f;
    private float _spawnInterval = 7;
    private float timer =0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= _spawnInterval)
        {
            SpawnBarrier();
            timer = 0f;
            _spawnInterval= Random.Range(_minSpawnInterval, _maxSpawnInterval);
        }
    }

    private int Randomplatform()
    {
        return Random.Range(0, _platformObjects.Length);
    }
    private void SpawnBarrier()
    {
        Instantiate(_platformObjects[Randomplatform()], transform.position, Quaternion.identity);
    }
}
