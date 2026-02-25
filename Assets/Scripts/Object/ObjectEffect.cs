using UnityEditor;
using UnityEngine;

public class ObjectBonus : MonoBehaviour
{
    [SerializeField] private int ObjectValue = 1;
    [SerializeField] PlayerCollect playerCollect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Bonus"))
        {
            playerCollect.UpdateScore(ObjectValue);
            Destroy(other.gameObject);
        }
    }
}
