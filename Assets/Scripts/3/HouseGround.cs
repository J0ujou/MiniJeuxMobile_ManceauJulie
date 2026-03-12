using UnityEngine;
using UnityEngine.UIElements;

public class HouseGround : MonoBehaviour
{
    [SerializeField] FloorHeight _floorHeight;
    [SerializeField] SpawnHouse _spawnHouse;


    private void Update()
    {
        _floorHeight = _spawnHouse.lastSpawnedFloor.GetComponent<FloorHeight>();
    }

    private void OnEnable()
    {
        _floorHeight.MooveGround += MooveGround;
    }

    private void OnDisable()
    {
        _floorHeight.MooveGround -= MooveGround;
    }



    public void MooveGround()
    {
        transform.Translate(-1, -1 * Time.deltaTime, 0);
        Debug.Log("MooveGround");
    }
}
