using System.Collections;
using UnityEngine; //amanina

public class ArcheryController : MonoBehaviour
{
    public float moveSpeed = 5f;             // Speed of the player movement
    public GameObject arrowPrefab;           // Prefab for the arrow
    public Transform arrowSpawnPoint;        // Point where arrows spawn
    public float arrowSpawnDelay = 0.5f;     // Delay between each arrow spawn
    public float arrowMoveSpeed = 30.0f;     // Speed assigned to each arrow
    public float spawnDuration = 330f;       // Duration for which arrows will spawn
    public HeartManager heartManager;        // Reference to HeartManager

    private Coroutine arrowSpawnCoroutine;   // Coroutine reference for spawning arrows

    private void Start()
    {
        if (arrowPrefab == null)
        {
            Debug.LogWarning("Arrow prefab is not assigned in the inspector.");
        }

        if (arrowSpawnPoint == null)
        {
            Debug.LogWarning("Arrow spawn point is not assigned in the inspector.");
        }

        // Start spawning arrows if the prefab and spawn point are assigned
        if (arrowPrefab != null && arrowSpawnPoint != null)
        {
            arrowSpawnCoroutine = StartCoroutine(SpawnArrows());
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.fixedDeltaTime;
        transform.Translate(movement);

        // Keep the arrow spawn point consistently above the player
        if (arrowSpawnPoint != null)
        {
            arrowSpawnPoint.position = transform.position + Vector3.up * 0.5f;
        }
    }

    private IEnumerator SpawnArrows()
    {
        float startTime = Time.time;
        Debug.Log("Arrow spawning started.");

        while (Time.time - startTime < spawnDuration)
        {
            // Stop spawning if the game is over
            if (heartManager != null && heartManager.IsGameOver)
            {
                Debug.Log("Game over! Stopping arrow spawning.");
                yield break;
            }

            // Spawn an arrow
            if (arrowPrefab != null && arrowSpawnPoint != null)
            {
                GameObject newArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.identity);

                // Set the speed of the new arrow
                if (newArrow != null)
                {
                    Arrow arrowScript = newArrow.GetComponent<Arrow>();
                    if (arrowScript != null)
                    {
                        arrowScript.moveSpeed = arrowMoveSpeed;
                    }
                    else
                    {
                        Debug.LogWarning("Arrow script missing on the arrow prefab.");
                    }
                }
                else
                {
                    Debug.LogWarning("Failed to instantiate arrow. Check if arrowPrefab is correctly assigned.");
                }
            }

            // Wait before spawning the next arrow
            yield return new WaitForSeconds(arrowSpawnDelay);
        }

        Debug.Log("Arrow spawning stopped after " + spawnDuration + " seconds.");
    }
}
