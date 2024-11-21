using UnityEngine;
using UnityEngine.UI; //Eve

public class FreezeButton : MonoBehaviour
{
    public Button freezeButton;                    // Reference to the freeze button UI element
    public CatSpawner catSpawner;                 // Reference to the CatSpawner script
    public float freezeDuration = 5f;             // Duration of freeze effect
    private int milestoneIncrement = 1000;        // Increment for milestones (1000, 2000, etc.)
    private int nextMilestone = 1000;             // The next milestone at which the button becomes active

    private void Start()
    {
        freezeButton.interactable = false;

        // Ensure the freeze button has a listener attached
        if (freezeButton != null)
        {
            freezeButton.onClick.AddListener(OnFreezeButtonClick);
        }
        else
        {
            Debug.LogError("Freeze button is not assigned in the Inspector.");
        }
    }

    private void Update()
    {
        UpdateButtonInteractable();
    }

    private void UpdateButtonInteractable()
    {
        // Ensure the ScoreManager is initialized before accessing it
        if (ScoreManager.Instance != null)
        {
            int currentScore = ScoreManager.Instance.CurrentScore;

            // Enable the button only when the current score matches the next milestone
            if (currentScore >= nextMilestone)
            {
                freezeButton.interactable = true;
            }
        }
        else
        {
            Debug.LogError("ScoreManager.Instance is null! Ensure a ScoreManager exists in the scene.");
        }
    }

    private void OnFreezeButtonClick()
    {
        if (catSpawner != null)
        {
            catSpawner.FreezeSpawner();            // Trigger the freeze functionality in CatSpawner

            // Update the next milestone
            nextMilestone += milestoneIncrement;

            // Disable the button until the next milestone
            freezeButton.interactable = false;
        }
        else
        {
            Debug.LogError("CatSpawner is not assigned in FreezeButton.");
        }
    }
}
