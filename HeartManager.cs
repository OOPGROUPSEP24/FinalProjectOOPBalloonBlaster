using UnityEngine; //fasya

public class HeartManager : MonoBehaviour
{
    public GameObject[] hearts;          // Assign Heart1, Heart2, and Heart3 in the inspector
    public GameObject gameOverPanel;     // Reference to the GameOver panel in the inspector
    private int heartIndex = 0;
    private bool isGameOver = false;

    private void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public bool IsGameOver => isGameOver;

    public void LoseHeart()
    {
        if (heartIndex < hearts.Length)
        {
            hearts[heartIndex].SetActive(false);
            heartIndex++;
        }

        if (heartIndex >= hearts.Length)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        Debug.Log("Game Over!");
    }
}
