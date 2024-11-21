using UnityEngine; //adriana amanina
using UnityEngine.UI;
using System.Collections;

public class LargeButton : MonoBehaviour
{
    public Button balloonButton;                  // Reference to the balloon size increase button UI element
    public float scaleIncreaseFactor = 2f;        // Factor by which the balloon size will increase
    public float revertDelay = 5f;               // Time in seconds before balloons revert to their original size
    private int milestoneIncrement = 3000;        // Score increment for milestones
    private int nextMilestone = 3000;             // Initial milestone for button activation
    private bool isBalloonsScaled = false;        // Tracks if balloons are already scaled

    private void Start()
    {
        balloonButton.interactable = false;       // Initially, the button is not interactable
        balloonButton.onClick.AddListener(OnBalloonButtonClick);  // Set up the button click listener
    }

    private void Update()
    {
        UpdateButtonInteractable();
    }

    // Update the button interactability based on score
    private void UpdateButtonInteractable()
    {
        if (ScoreManager.Instance != null)
        {
            int currentScore = ScoreManager.Instance.CurrentScore;

            // Enable the button if the current score reaches the next milestone and balloons aren't already scaled
            if (currentScore >= nextMilestone && !isBalloonsScaled)
            {
                balloonButton.interactable = true;
            }
            else
            {
                balloonButton.interactable = false;
            }
        }
        else
        {
            Debug.LogError("ScoreManager.Instance is null!");
        }
    }

    // Button click handler to increase the size of the balloons
    private void OnBalloonButtonClick()
    {
        if (ScoreManager.Instance != null && ScoreManager.Instance.CurrentScore >= nextMilestone)
        {
            // Prevent balloons from being scaled again until reverted
            isBalloonsScaled = true;

            // Scale balloons and start the revert process
            StartCoroutine(ScaleAndRevertBalloons<PurpleBalloon>());
            StartCoroutine(ScaleAndRevertBalloons<WhiteBalloon>());
            StartCoroutine(ScaleAndRevertBalloons<PinkBalloon>());

            // Update the next milestone for button activation
            nextMilestone += milestoneIncrement;

            // Disable the button immediately after it's used
            balloonButton.interactable = false;
        }
    }

    // Scales all active balloons of a specific type and reverts their size after the delay
    private IEnumerator ScaleAndRevertBalloons<T>() where T : MonoBehaviour
    {
        T[] balloons = FindObjectsOfType<T>(); // Find all active balloons of this type

        foreach (var balloon in balloons)
        {
            if (balloon != null)
            {
                // Store the original scale before increasing
                Vector3 originalScale = balloon.transform.localScale;

                // Set the balloon's size to the increased scale
                balloon.transform.localScale *= scaleIncreaseFactor;
            }
        }

        // Wait for the specified delay
        yield return new WaitForSeconds(revertDelay);

        foreach (var balloon in balloons)
        {
            if (balloon != null)
            {
                // Revert the balloon's size to its original scale
                balloon.transform.localScale /= scaleIncreaseFactor;
            }
        }

        // Allow balloons to scale again when another milestone is reached
        isBalloonsScaled = false;
    }
}
