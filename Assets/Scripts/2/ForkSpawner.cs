using UnityEngine;

public class ForkSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ForkPrefab;
    [SerializeField] private float _maxSpawnInterval = 8f;
    [SerializeField] private float _minSpawnInterval = 4f;
    private float spawnInterval = 4f;
    private float timer =0f;
    
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
                SpawnFork();
                timer = 0f;
                spawnInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
            
        }
    }
    public void SpawnFork()
    {
            Instantiate(ForkPrefab, transform.position, Quaternion.identity);
        
    }
}
