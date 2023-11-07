using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score, lives;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public GameObject pauseScreen;
    private bool paused;
    //public Slider volumeSlider;
    public bool isGameActive;
    public Button restartButton;
    public Button quitButton;
    public GameObject tittleScreen;
    [SerializeField] Texture2D cursorArrow;
    void Start()
    {
       
        lives = 3;
        UpdateLives(0);
        UpdateScore(0);
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            CheckForPaused();
        }
    }

    IEnumerator SpawnTarget() {
        while (isGameActive) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

   
    public int UpdateScore(int newScore)
    {
        score += newScore;
        scoreText.text = "Score: " + score;
        return score;
        
    }

    public int UpdateLives(int newLives)
    {
        
        lives += newLives;
        livesText.text = "Lives: " + lives;
        return lives;
    }
    public void GameOver()
    {
             restartButton.gameObject.SetActive(true);
             quitButton.gameObject.SetActive(true);
             isGameActive = false;
             gameOverText.gameObject.SetActive(true);
    }

  

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game clicked");
    }
    public void StartGame(float difficulty)
    {
        isGameActive = true;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        tittleScreen.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    void CheckForPaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
            isGameActive = false;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

}
