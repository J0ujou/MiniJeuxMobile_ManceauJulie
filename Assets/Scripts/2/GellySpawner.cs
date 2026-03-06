using UnityEngine;

public class GellySpawner : MonoBehaviour
{
    [SerializeField] private Sprite[] GellySprites;
    [SerializeField] private GameObject GellyPrefab;
    [SerializeField] private float _maxSpawnInterval = 4f;
    [SerializeField] private float _minSpawnInterval = 4f;
    private float spawnInterval = 10;
    private float timer =0f;
    private SpriteRenderer spriteR;

    private void Start()
    {
        spriteR = GellyPrefab.GetComponent<SpriteRenderer>();
    }
    
    private void RandomColorgelly()
    {
         spriteR.sprite = GellySprites[Random.Range(0, GellySprites.Length)];
    }
    
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnGelly();
            timer = 0f;
            spawnInterval= Random.Range(_minSpawnInterval, _maxSpawnInterval);
        }
    }
    private void SpawnGelly()
    {
        RandomColorgelly();
        Instantiate(GellyPrefab, transform.position, Quaternion.identity);
    }
}
