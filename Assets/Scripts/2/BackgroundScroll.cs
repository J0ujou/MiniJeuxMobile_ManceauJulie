using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector2.left * (scrollSpeed * Time.deltaTime));
        if (transform.position.x < -23f)
        {
            transform.position = new Vector2(23f, transform.position.y);
        }
    }
}
