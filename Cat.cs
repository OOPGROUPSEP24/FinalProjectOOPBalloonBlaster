using UnityEngine; //fasya

public class Cat : MonoBehaviour
{
    public float fallSpeed = 2f;
    public GameObject catPowPrefab; // Reference to the cat pow prefab
    private HeartManager heartManager;
    private Camera mainCamera;  // Cached reference to Camera.main

    void Start()
    {
        // Locate the HeartManager in the scene
        heartManager = FindObjectOfType<HeartManager>();

        if (heartManager == null)
        {
            Debug.LogError("HeartManager not found in the scene!");
        }

        // Cache the main camera for efficiency
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Move the cat downward
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        
        // Check if cat is below the screen bounds and destroy if so
        if (mainCamera != null)
        {
            Vector2 min = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
            if (transform.position.y < min.y)
            {
                Destroy(gameObject);  // Destroy the cat if it goes off screen
            }
        }
        else
        {
            Debug.LogError("Main camera is missing!");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the cat collides with an object tagged as "Arrow"
        if (collision.CompareTag("Arrow"))
        {
            Debug.Log("Arrow hit the cat!"); // Debug message for collision

            // Instantiate the cat pow effect at the cat's position
            if (catPowPrefab != null)
            {
                Instantiate(catPowPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("Cat pow prefab is missing!");
            }

            // Destroy the arrow and cat on collision
            Destroy(collision.gameObject);
            Destroy(gameObject);

            // Call LoseHeart in HeartManager if available
            if (heartManager != null)
            {
                heartManager.LoseHeart();
            }
            else
            {
                Debug.LogWarning("HeartManager is missing, cannot lose heart!");
            }
        }
    }
}
