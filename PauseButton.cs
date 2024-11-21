using UnityEngine;     // nuradriana
using UnityEngine.SceneManagement; // To load new scenes, e.g., exit to main menu or quit game.
using UnityEngine.UI;              // For Button interaction

public class PauseButton : MonoBehaviour
{
    public GameObject pausePanel;          // Reference to the Pause Panel
    public Button resumeButton;            // Reference to the Resume button
    public Button exitButton;              // Reference to the Exit button

    private bool isPaused = false;         // To track if the game is paused

    private void Start()
    {
        
        pausePanel.SetActive(false);

        // Add listeners to the buttons
        resumeButton.onClick.AddListener(OnResumeButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    // Method to toggle pause
    public void OnPauseButtonClick()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // If the game is paused, show the pause panel and freeze the game time
            Time.timeScale = 0f;  // Pause the game
            pausePanel.SetActive(true); // Show the pause panel
        }
        else
        {
            // If the game is unpaused, hide the pause panel and resume the game time
            Time.timeScale = 1f;  // Resume the game
            pausePanel.SetActive(false); // Hide the pause panel
        }
    }

    // Method to resume the game
    private void OnResumeButtonClick()
    {
        isPaused = false; // Set the game state back to unpaused
        Time.timeScale = 1f; // Resume the game time
        pausePanel.SetActive(false); // Hide the pause panel
    }

    // Method to exit the game
    private void OnExitButtonClick()
    {
       
        Debug.Log("Exiting the game...");
        Application.Quit(); // This will quit the game when running as a build.

       
        // SceneManager.LoadScene("MainMenuScene");  // 
    }
}
