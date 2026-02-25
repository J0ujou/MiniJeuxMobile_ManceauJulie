using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _barrierObjects;
    
    [Header("Spawing Details")]
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

    private int RandomBarrier()
    {
        return Random.Range(0, _barrierObjects.Length);
    }
    private void SpawnBarrier()
    {
        Instantiate(_barrierObjects[RandomBarrier()], transform.position, Quaternion.identity);
    }
}
