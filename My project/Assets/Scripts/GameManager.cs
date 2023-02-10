using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;

    public Text scoreText;
    public Text topScoreText;
    public GameObject recordText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject menuText;

    private int score;
    private int topScore;
    public float speed;
    public float difficulty;

    private void Awake()
    {
        FindObjectOfType<Spawner>().enable = true;
        scoreText.text = "";
        recordText.SetActive(false);
        gameOver.SetActive(false);

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        FindObjectOfType<Spawner>().enable = true;
        playButton.SetActive(false);
        gameOver.SetActive(false);
        menuText.SetActive(false);
        recordText.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        speed = difficulty;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }


    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Debug.Log("Game over");
        FindObjectOfType<Spawner>().enable = false;
        speed = 0f;
        TopScore();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void TopScore()
    {
        if (score > topScore)
        {
            topScore = score;
            topScoreText.text = topScore.ToString();
            recordText.SetActive(true);
        }
    }

    public void IncreaseSpeed()
    {
        speed += difficulty * Time.deltaTime;
    }
}
