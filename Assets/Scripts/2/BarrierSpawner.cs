using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _barrierObjects;
    
    [Header("Spawing Details")]
    [SerializeField] private float _maxSpawnInterval = 4f;
    [SerializeField] private float _minSpawnInterval = 2f;
    private float _spawnInterval = 4f;

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

    private int RandomBarrier()
    {
        return Random.Range(0, _barrierObjects.Length);
    }
    private void SpawnBarrier()
    {
        Instantiate(_barrierObjects[RandomBarrier()], transform.position, Quaternion.identity);
    }
}
