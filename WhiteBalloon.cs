using UnityEngine;  // nuradriana

public class WhiteBalloon : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (ScoreManager.Instance == null)
        {
            Debug.LogError("ScoreManager Instance is null!");
            return;
        }

        // Trigger explode animation
        Explode();

        // Add points to the score
        ScoreManager.Instance.AddScore(250);

        // Destroy this balloon
        Destroy(gameObject);
    }

    private void Explode()
    {
        Debug.Log("White Balloon Exploded!");
    }
}
