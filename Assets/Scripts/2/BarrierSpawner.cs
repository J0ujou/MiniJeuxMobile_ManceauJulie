using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _barrierObjects;
    [SerializeField] private GellySpawner _gellySpawner;
    [SerializeField] private CollectibleSpawner _collectibleSpawner;
    [Header("Spawing Details")]
    [SerializeField] private float _maxSpawnInterval = 4f;
    [SerializeField] private float _minSpawnInterval = 2f;
    private float _spawnInterval = 5f;
    

    private float timer =0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= _spawnInterval)
        {
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
