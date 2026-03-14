
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
  _topLimit.SpawnLastFloor += SpawnLastFloor;
 }

 private void OnDisable()
 {
  _scoreSuika.SpawnFloor -= SpawnerHouse;
  _topLimit.SpawnLastFloor -= SpawnLastFloor;
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
   lastSpawnedFloor = Instantiate(HousePrefabs[randomFLoor()], transform.position, Quaternion.identity);
  }
  else
  {
   lastSpawnedFloor = Instantiate(HousePrefabs[0], transform.position, Quaternion.identity);
  }
 }


 private int randomFLoor()
 {
   return Random.Range(2, HousePrefabs.Length);
 }


public void SpawnLastFloor()
{
 lastSpawnedFloor = Instantiate(HousePrefabs[1], transform.position, Quaternion.identity);
 _topLimit.NbFloorText(NbFloor+1);
}
}