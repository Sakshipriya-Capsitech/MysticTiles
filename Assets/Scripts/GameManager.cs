using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [Header("UI References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject startButton;
    public GameObject gameOverText;
    public GameObject restartButton;
     public GameObject ExitButton;
    private int score = 0;
    private bool gameActive = false;
    public float platformFallDelay = 3f;
    private int highScore = 0;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
         highScore = PlayerPrefs.GetInt("HighScore", 0);
        ShowStartMenu();
    }

   
    public void StartGame()
    {
        gameActive = true;
        score = 0;
        scoreText.text = "Score: 0";

        startButton.SetActive(false);
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        ExitButton.SetActive(false);
    }

    
    public void AddScore(int amount)
    {
        if (!gameActive) return;

        score += amount;
        scoreText.text = "Score: " + score;

         highScoreText.text = "High Score: " + highScore;
    }


    public void GameOver()
    {

        gameActive = false;
         if(score > highScore)
        {
        highScore = score;
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
       }
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        ExitButton.SetActive(true);
        PlatformSpawner spawner = FindObjectOfType<PlatformSpawner>();
        foreach (GameObject platform in spawner.GetAllPlatforms())
        {
           if (platform == null) continue;
        PlatformTile tile = platform.GetComponent<PlatformTile>();
           if (tile != null)
        {
           tile.StartFalling(0f);
           }
        }

    }
    
        public void ExitGame()
    {
        Application.Quit(); 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void ShowStartMenu()
    {
        startButton.SetActive(true);
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        ExitButton.SetActive(false);

        highScoreText.text = "High Score: " + highScore;


    }

    public bool IsGameActive()
    {
        return gameActive;
    }


}
