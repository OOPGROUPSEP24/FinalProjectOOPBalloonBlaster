using UnityEngine;
using UnityEngine.UI; //Eve

public class FastButton : MonoBehaviour
{
    public Button fastButton;                // Reference to the button
    public ArcheryController archery;        // Reference to the ArcheryController
    public float fastArrowSpeed = 50f;       // New arrow speed when fast mode is active
    public float fastSpawnDelay = 0.25f;     // New spawn delay when fast mode is active
    public float defaultArrowSpeed = 30f;    // Default arrow speed
    public float defaultSpawnDelay = 0.5f;   // Default spawn delay
    private bool isFastMode = false;         // Tracks whether fast mode is active
    private int milestoneIncrement = 5000;  // Score increment for milestones
    private int nextMilestone = 5000;        // Initial milestone for button activation

    private void Start()
    {
        // Ensure the button is assigned
        if (fastButton != null)
        {
            fastButton.onClick.AddListener(OnFastButtonPress);
            fastButton.interactable = false; // Initially, the button is not interactable
        }
        else
        {
            Debug.LogWarning("FastButton not assigned in inspector.");
        }
    }

    private void Update()
    {
        // Check if ScoreManager exists
        if (ScoreManager.Instance == null)
        {
            Debug.LogError("ScoreManager.Instance is null! Make sure a ScoreManager is in the scene.");
            return;
        }

        int currentScore = ScoreManager.Instance.CurrentScore;

        // Enable the button only when the current score reaches the next milestone and fast mode is not active
        if (currentScore >= nextMilestone && !isFastMode)
        {
            fastButton.interactable = true;
        }
        else
        {
            fastButton.interactable = false;
        }
    }

    private void OnFastButtonPress()
    {
        if (archery == null)
        {
            Debug.LogError("ArcheryController is not assigned in FastButton.");
            return;
        }

        // Activate fast mode
        isFastMode = true;

        // Set the archery arrow speed and spawn delay to fast values
        archery.arrowMoveSpeed = fastArrowSpeed;
        archery.arrowSpawnDelay = fastSpawnDelay;

        // Schedule a return to normal mode after a delay (e.g., 10 seconds)
        Invoke(nameof(DisableFastMode), 10f);

        // Set the next milestone for the button activation
        nextMilestone += milestoneIncrement;

        // Disable the button until the next milestone
        fastButton.interactable = false;
    }

    private void DisableFastMode()
    {
        if (archery == null)
        {
            Debug.LogError("ArcheryController is not assigned in FastButton.");
            return;
        }

        // Revert to default values
        archery.arrowMoveSpeed = defaultArrowSpeed;
        archery.arrowSpawnDelay = defaultSpawnDelay;

        // Exit fast mode
        isFastMode = false;
    }
}
