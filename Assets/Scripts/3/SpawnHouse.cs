
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnHouse : MonoBehaviour
{
 
 [SerializeField] TopLimit _topLimit;
 [SerializeField] GameObject[] HousePrefabs;
 [SerializeField] UIScoreSuika _scoreSuika;
 private int NbFloor = 0;
 public GameObject lastSpawnedFloor = null;

 private void OnEnable()
 {
  _scoreSuika.SpawnFloor += SpawnerHouse;
  _topLimit.SpawnLastFloor += SpawnerHouse;
 }

 private void OnDisable()
 {
  _scoreSuika.SpawnFloor -= SpawnerHouse;
  _topLimit.SpawnLastFloor -= SpawnerHouse;
 }

 private void Start()
 {
  NbFloor = 0;
 }

 public void SpawnerHouse()
 {
  NbFloor++;
  Debug.Log("Spawn House");
  if (NbFloor > 1)
  {
   lastSpawnedFloor = HousePrefabs[randomFLoor()];
   Instantiate(lastSpawnedFloor, transform.position, Quaternion.identity);
  }
  else
  {
   lastSpawnedFloor = HousePrefabs[0];
   Instantiate( lastSpawnedFloor, transform.position, Quaternion.identity);
  }
 }


 private int randomFLoor()
 {
   return Random.Range(2, HousePrefabs.Length);
 }


public void SpawnLastFloor()
{
 lastSpawnedFloor = HousePrefabs[1];
 Instantiate( lastSpawnedFloor, transform.position, Quaternion.identity);
}
}