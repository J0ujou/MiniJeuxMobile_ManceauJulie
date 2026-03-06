using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject CollectiblePrefab;
    [SerializeField] private float _maxSpawnInterval = 10f;
    [SerializeField] private float _minSpawnInterval = 4f;
    [SerializeField] Shield shield;
    private float spawnInterval = 10;
    private float timer =0f;
    
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            if (!shield.shielded)
            {
                SpawnCollectible();
                timer = 0f;
                spawnInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
            }
        }
    }
    public void SpawnCollectible()
    {
        Instantiate(CollectiblePrefab, transform.position, Quaternion.identity);
    }
}
