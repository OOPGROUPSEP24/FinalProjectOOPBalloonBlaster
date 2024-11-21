using UnityEngine; //Fasya

public class CatSpawner : MonoBehaviour
{
    public float spawnInterval = 5f;               // Interval between cat spawns
    public GameObject[] catPrefabs;                // Array of cat prefabs to spawn
    public HeartManager heartManager;              // Reference to HeartManager to check game-over status
    public GameObject freezeModeTextPrefab;        // Reference to freeze animation prefab
    public Vector3 freezeEffectOffset = new Vector3(0, 0, 1); // Offset for the freeze animation position
    public float freezeDuration = 3f;              // Duration of the freeze effect
    private bool isFrozen = false;                 // Tracks if the spawner is frozen

    private void Start()
    {
        DontDestroyOnLoad(gameObject);              // Make this object persist across scenes
        InvokeRepeating(nameof(SpawnCat), 0f, spawnInterval); // Start spawning cats at intervals
    }

    private void SpawnCat()
    {
        // Only spawn if not frozen and the game is not over
        if (isFrozen || (heartManager != null && heartManager.IsGameOver))
        {
            return;
        }

        // Ensure there are cat prefabs assigned
        if (catPrefabs != null && catPrefabs.Length > 0)
        {
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            // Select a random cat prefab from the array
            GameObject catPrefab = catPrefabs[Random.Range(0, catPrefabs.Length)];

            if (catPrefab != null)
            {
                GameObject cat = Instantiate(catPrefab);
                cat.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
            }
            else
            {
                Debug.LogError("Cat prefab is null! Check the catPrefabs array in the Inspector.");
            }
        }
        else
        {
            Debug.LogError("No cat prefabs assigned to CatSpawner. Please assign cat prefabs in the Inspector.");
        }
    }

    /// <summary>
    /// Freezes the spawner for a specified duration, preventing cats from spawning.
    /// </summary>
    public void FreezeSpawner()
    {
        if (!isFrozen)
        {
            isFrozen = true;                         // Mark the spawner as frozen
            CancelInvoke(nameof(SpawnCat));         // Stop spawning cats immediately

            // Display the freeze animation effect
            if (freezeModeTextPrefab != null)
            {
                // Calculate the position for the freeze effect (center of the camera with offset)
                Vector3 freezePosition = Camera.main.transform.position + Camera.main.transform.forward + freezeEffectOffset;

                // Instantiate the freeze effect prefab
                GameObject freezeEffect = Instantiate(freezeModeTextPrefab, freezePosition, Quaternion.identity);
                Destroy(freezeEffect, freezeDuration); // Destroy the freeze effect after its duration
            }
            else
            {
                Debug.LogError("FreezeModeTextPrefab is not assigned. Assign it in the Inspector.");
            }

            // Schedule resuming spawning after the freeze duration
            Invoke(nameof(ResumeSpawning), freezeDuration);
        }
    }

    /// <summary>
    /// Resumes the cat spawning after the freeze duration.
    /// </summary>
    private void ResumeSpawning()
    {
        isFrozen = false;                           // Mark the spawner as active again
        InvokeRepeating(nameof(SpawnCat), 0f, spawnInterval); // Resume spawning cats at the set interval
    }
}
