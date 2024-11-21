using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; //Erina

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } // Singleton instance
    public TextMeshProUGUI scoreText;                         // Reference to the UI Text for score display (game scene only)
    public TextMeshProUGUI highScoreText;                     // Reference to the UI Text for high score display (menu)

    private int score = 0;                                    // Private field to track the score
    private int highScore = 0;                                // Private field to track the highest score

    private void Awake()
{ if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject); // Only the ScoreManager persists
    }
    else
    {
        Destroy(gameObject); // Prevent duplicate instances
    }

}

    public void AddScore(int points)
    {
        score += points;                                      // Increment the score
        UpdateScoreText();                                    // Update the score display
    }

   
private void UpdateScoreText()
{
    // Check if the active scene is the Game Scene
    if (SceneManager.GetActiveScene().name == "balloonblasterfinal" && scoreText != null)
    {
        scoreText.text = $"SCORE : {score:D4}";
    }
    else if (SceneManager.GetActiveScene().name != "balloonblasterfinal")
    {
        // If not in the Game Scene, avoid updating the score
        Debug.Log("Score is not updated because this is not the Game Scene.");
    }
}
    public void DisplayHighScore()
    {
        if (highScoreText != null)                            // Check if highScoreText is assigned in the menu
        {
            // Format the high score as four digits with leading zeros
            highScoreText.text = $"HIGH SCORE : {highScore:D4}";
        }
    }

    public int CurrentScore => score;                         // Property to get the current score (read-only)

    public void GameOver()
    {
        if (score > highScore)                                // Update high score if the current score is greater
        {
            highScore = score;
        }

        ResetScore();                                         // Reset the current score
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();                                    // Ensure the score is updated in the game scene
    }
}
