using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int winScore = 10;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI statusText;

    public PlayerController playerController;

    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject gameOverPanel;

    private bool gameEnded = false;
    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1f;

        score = 0;
        gameEnded = false;
        isPaused = false;

        statusText.text = "";

        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (winPanel != null)
            winPanel.SetActive(false);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateScoreText();
    }

    void Update()
    {
        if (!gameEnded && Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        if (!gameEnded && !isPaused && Input.GetKeyDown(KeyCode.L))
        {
            playerController.ToggleInputMode();

            UpdateScoreText();

            statusText.text = playerController.useLSLInput
                ? "LSL MODE"
                : "KEYBOARD MODE";

            CancelInvoke(nameof(ClearStatusText));
            Invoke(nameof(ClearStatusText), 1.5f);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void AddScore(int amount)
    {
        if (gameEnded || isPaused)
            return;

        score += amount;
        UpdateScoreText();

        if (score >= winScore)
        {
            WinGame();
        }
    }

    public void GameOver()
    {
        if (gameEnded)
            return;

        gameEnded = true;
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (winPanel != null)
            winPanel.SetActive(false);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        statusText.text = "";

        playerController.DestroyPlayer();
    }

    public void WinGame()
    {
        if (gameEnded)
            return;

        gameEnded = true;
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (winPanel != null)
            winPanel.SetActive(true);

        statusText.text = "";

        playerController.StopPlayer();
    }

    void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;

            if (pausePanel != null)
                pausePanel.SetActive(true);

            statusText.text = "";
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        statusText.text = "";
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }

    void ClearStatusText()
    {
        if (!gameEnded && !isPaused)
        {
            statusText.text = "";
        }
    }

    void UpdateScoreText()
    {
        string modeText = playerController.useLSLInput
            ? "LSL"
            : "Keyboard";

        scoreText.text =
            "Score: " + score + " / " + winScore +
            "\nMode: " + modeText;
    }
}