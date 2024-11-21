using UnityEngine;
using UnityEngine.SceneManagement; //Erina

public class MenuManager : MonoBehaviour
{
    public GameObject settingsPanel; // Reference to the Settings Panel

    // Called when the Start button is clicked
    public void OnStartButtonClicked()
    {
        Debug.Log("Start button clicked!");
        // Load the main game scene (replace "GameScene" with your scene's name)
        SceneManager.LoadScene("GameScene");
    }

    // Called when the Settings button is clicked
    public void OnSettingsButtonClicked()
    {
        Debug.Log("Settings button clicked!");
        // Toggle the visibility of the settings panel
        if (settingsPanel != null)
        {
            bool isActive = settingsPanel.activeSelf;
            settingsPanel.SetActive(!isActive); // Show/Hide the panel
        }
        else
        {
            Debug.LogError("Settings panel is not assigned!");
        }
    }

    // Called when the Exit button is clicked
    public void OnExitButtonClicked()
    {
        Debug.Log("Exit button clicked!");
        // Quit the application
        Application.Quit();

        // Note: This won't stop the editor; add this line for testing in the editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
