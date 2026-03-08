using UnityEngine;

public class BarrierBehaviour : MonoBehaviour
{
    [SerializeField]  public float _barrierMovementSpeed = 5f;
    [SerializeField] private float _screenExit = -15f;
    private Rigidbody2D _barrierRigidbody;
    [SerializeField] private ScoreDatas scoreDatas;

    private void Start()
    {
        //scoreDatas.BarrierSpeed = 5f;
        //_barrierMovementSpeed = 5f;
        _barrierRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _barrierMovementSpeed = scoreDatas.BarrierSpeed;
        //deplace barrier vers la gauche
        transform.Translate(Vector2.left * (_barrierMovementSpeed * Time.deltaTime));
        // destroy quand sort de l'écran
        if (transform.position.x < _screenExit)
        {
            Destroy(gameObject);
        }
        
    }
}
