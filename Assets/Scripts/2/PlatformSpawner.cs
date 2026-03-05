using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _platformObjects;
    
    [SerializeField] private float _maxSpawnInterval = 4f;
    private float timer =0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= _maxSpawnInterval)
        {
            SpawnBarrier();
            timer = 0f;
            _maxSpawnInterval= Random.Range(1, _maxSpawnInterval);
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
