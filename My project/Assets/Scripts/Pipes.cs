using UnityEngine;

public class Pipes : MonoBehaviour
{
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x-1f;

    }

    private void Update()
    {
        transform.position += Vector3.left * FindObjectOfType<GameManager>().speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {  
            Destroy(gameObject);
        }
    }
}
