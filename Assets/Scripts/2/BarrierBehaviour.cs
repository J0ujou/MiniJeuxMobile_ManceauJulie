using UnityEngine;

public class BarrierBehaviour : MonoBehaviour
{
    [SerializeField] private float _barrierMovementSpeed = 5f;
    [SerializeField] private float _screenExit = -10f;
    [SerializeField] private Rigidbody2D _barrierRigidbody;

    private void Start()
    {
        _barrierRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //deplace barrier vers la gauche
        transform.Translate(Vector2.left * (_barrierMovementSpeed * Time.deltaTime) );
        // destroy quand sort de l'écran
        if (transform.position.x < _screenExit)
        {
            Destroy(gameObject);
        }
    }
}
