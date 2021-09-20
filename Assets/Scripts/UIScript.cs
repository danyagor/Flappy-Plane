using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIScript : MonoBehaviour {

    // Menu
    public Canvas menuCanvas;

    // Game
    public Canvas gameCanvas;
    public Text scoreText;

    // About
    public Canvas aboutCanvas;
    public Canvas versionCanvas;

    // Game over
    public Canvas gameOverCanvas;
    public Text finalScoreText;
    public Text bestScoreText;
    public Text newBestScoreText;

    int finalScore = 0;
    int bestScore = 0;

    void Awake()
    {
        Messenger<int>.AddListener(GameEvents.SCORED, Scored);
        Messenger.AddListener(GameEvents.GAME_OVER, GameOver);
    }
    void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvents.SCORED, Scored);
        Messenger.RemoveListener(GameEvents.GAME_OVER, GameOver);
    }

    // Use this for initialization
    void Start () {
        menuCanvas.enabled = true;
        versionCanvas.enabled = true;
        gameCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        aboutCanvas.enabled = false;

        newBestScoreText.enabled = false;

        bestScore = PlayerPrefs.GetInt("Best Score", 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        Messenger.Broadcast(GameEvents.GAME_STARTED);
        menuCanvas.enabled = false;
        gameCanvas.enabled = true;
        versionCanvas.enabled = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GameOver()
    {
        gameCanvas.enabled = false;
        gameOverCanvas.enabled = true;

        // Score
        finalScoreText.text = "Score: " + finalScore.ToString();
        if (finalScore > bestScore)
        {
            newBestScoreText.enabled = true;
            bestScore = finalScore;
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
        bestScoreText.text = "Best score: " + bestScore.ToString();
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteKey("Best Score");
    }

    public void About()
    {
        menuCanvas.enabled = false;
        aboutCanvas.enabled = true;
    }

    public void AboutBack()
    {
        menuCanvas.enabled = true;
        aboutCanvas.enabled = false;
    }

    void Scored(int score)
    {
        finalScore++;
        scoreText.text = score.ToString();
    }
}
