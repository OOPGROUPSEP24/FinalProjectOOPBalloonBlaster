using UnityEngine; // nuradriana

public class PurpleBalloon : MonoBehaviour
{
    public GameObject explosionPrefab; // Reference to the explosion prefab

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
        ScoreManager.Instance.AddScore(150);

        // Destroy this balloon
        Destroy(gameObject);
    }

    private void Explode()
{
    Debug.Log("Purple Balloon Exploded!");

    // Check if the explosion prefab is assigned
    if (explosionPrefab != null)
    {
        // Instantiate the explosion prefab at the root of the hierarchy
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Debug.Log("Explosion instantiated at position: " + transform.position);

        // Optional: Add a destroy timer to remove the explosion after its animation duration
        Destroy(explosion, 2.0f); // Adjust the duration to match the explosion animation length
    }
    else
    {
        Debug.LogError("Explosion prefab is not assigned to PurpleBalloon!");
    }
}


}
