using UnityEngine;
using UnityEngine.UIElements;

public class HouseGround : MonoBehaviour
{
    private FloorHeight _floorHeight;
    [SerializeField] SpawnHouse _spawnHouse;


    private void Update()
    {
        if (_spawnHouse.lastSpawnedFloor == null)
            return;
        
        FloorHeight newFloor = _spawnHouse.lastSpawnedFloor.GetComponent<FloorHeight>();

        // Se réabonner uniquement si le floor a changé
        if (newFloor != _floorHeight)
        {
            if (_floorHeight != null)
                _floorHeight.MooveGround -= MooveGround;

            _floorHeight = newFloor;

            if (_floorHeight != null)
                _floorHeight.MooveGround += MooveGround;

        }
    }

    private void OnDisable()
    {
        if (_floorHeight != null)
        {_floorHeight.MooveGround -= MooveGround;}
    }



    public void MooveGround()
    {
        transform.Translate(-1, -1 * Time.deltaTime, 0);
        Debug.Log("MooveGround");
    }
}
