using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnHouse : MonoBehaviour
{
 
 [SerializeField] TopLimit _topLimit;
 [SerializeField] GameObject[] HousePrefabs;
 private int NbFloor = 0;
 public GameObject lastSpawnedFloor = null;



 public event Action<int> Floorheight;

 private void Start()
 {
  SpawnerHouse();
 }

 public void SpawnerHouse()
 {
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
  NbFloor++;
 }


 private int randomFLoor()
 {
   return Random.Range(1, HousePrefabs.Length);
 }
}
