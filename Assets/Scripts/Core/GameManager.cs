using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager i;

    [SerializeField] bool levelPassed;
    [SerializeField] bool gameOver;
    [SerializeField] int numberOfBricks;
    [SerializeField] int numberOfLives;
    [SerializeField] int currentScore;
    [SerializeField] int currentLevel;

    [SerializeField] TMP_Text livesText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Transform gameOverPanel;
    [SerializeField] Transform loadlevelPanel;

    [SerializeField] Ball mainBall;
    [SerializeField] List<GameObject> allLevels;
    GameObject currentLevelObject;
    GameObject[] allBricks;


    private void Awake()
    {
        if (i == null)
        {
            i = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        LoadLevel();
        livesText.text = "Lives: " + numberOfLives;
        scoreText.text = "Score: " + currentScore;
    }

    void CountInitialBricks()
    {
        allBricks = GameObject.FindGameObjectsWithTag("Brick");
        for (int i = 0; i < allBricks.Length; i++)
        {
            var infiniteBrick = allBricks[i].GetComponent<InfinateBrick>();

            if (!infiniteBrick)
                numberOfBricks++;
        }
 
    }

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;

        if (numberOfBricks == 0)
        {
            LevelCleared();

            if (currentLevel < allLevels.Count)
            {
                Invoke("LoadLevel", 3f);
            }
            else
            {
                //GAME OVER
            }
        }
        
    }

    void LoadLevel()
    {
        currentLevelObject = Instantiate(allLevels[currentLevel], Vector2.zero, Quaternion.identity);
        levelPassed = false;
        loadlevelPanel.gameObject.SetActive(false);
        CountInitialBricks();

    }

    private void LevelCleared()
    {
        levelPassed = true;
        CleanupLevel();
        currentLevel++;
        loadlevelPanel.gameObject.SetActive(true);
        loadlevelPanel.GetComponentInChildren<TMP_Text>().text = "Loading Level " + (currentLevel + 1);
        //Destroy(allLevels[currentLevel].gameObject);

        mainBall.ResetBall();
    }

    void CleanupLevel()
    {
        currentLevelObject.SetActive(false);
        
    }

    public void UpdateNumberOfLives(int value = -1)
    {
        numberOfLives += value;
        livesText.text = "Lives: " + numberOfLives;

        if (numberOfLives == 0)
        {
            //game over
            GameOver();
        }
    }

    public void UpdateScore(int value)
    {
        currentScore += value;
        scoreText.text = "Score: " + currentScore;
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

}
