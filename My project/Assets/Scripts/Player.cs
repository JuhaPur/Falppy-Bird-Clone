using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;

    //gravity for falling  
    public float gravity = -9.81f;
    public float strength = 5f;
    public float crashStrength = 100f;

    private float bottom;

    private void Awake()
    {
        bottom = Camera.main.ScreenToWorldPoint(Vector3.zero).y;
        direction = Vector3.up * strength;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && FindObjectOfType<Spawner>().enable == true)
        {
            direction = Vector3.up * strength;
        }

        if (Input.touchCount > 0)
        {
            //for phone, touch
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
        //if the player goes past gameobject, this erases the gameobject from memory
        if (transform.position.y < bottom)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if player hits obstacle, game over
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
            FindObjectOfType<CameraShake>().Shake(0.05f, .1f);
            direction.x -= crashStrength * Time.deltaTime;

        }
        //if player hits top corner or bottom corner, game over
        else if (other.gameObject.tag == "Border")
        {
            FindObjectOfType<GameManager>().GameOver();
            FindObjectOfType<CameraShake>().Shake(0.15f, 0.2f);
            direction.x -= crashStrength * Time.deltaTime;
        }
        //scoring adds to the scoreboard and makes game harder(faster).
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            FindObjectOfType<GameManager>().IncreaseSpeed();
        }
    }
}
