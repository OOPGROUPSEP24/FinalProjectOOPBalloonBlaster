using UnityEngine;

public class Arrow : MonoBehaviour //amanina
{
    public float moveSpeed = 2f; // Speed of the arrow movement

    void Update()
    {
        // Moves the arrow upward at a specified speed
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        // Destroy the arrow when it goes off-screen
        if (transform.position.y > Camera.main.orthographicSize + 5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (ScoreManager.Instance == null)
        {
            Debug.LogError("ScoreManager Instance is null!");
            return;
        }

        // Check if the arrow collides with a balloon or another object
        if (collision.CompareTag("Pinkballoon"))
        {
            // Add score for Pink Balloon and destroy it
            ScoreManager.Instance.AddScore(200);
            Destroy(collision.gameObject);  // Destroy the balloon
            Destroy(gameObject);  // Destroy the arrow
        }
        else if (collision.CompareTag("Purpleballoon"))
        {
            // Add score for Purple Balloon and destroy it
            ScoreManager.Instance.AddScore(150);
            Destroy(collision.gameObject);  // Destroy the balloon
            Destroy(gameObject);  // Destroy the arrow
        }
        else if (collision.CompareTag("WhiteBalloon"))
        {
            // Add score for White Balloon and destroy it
            ScoreManager.Instance.AddScore(250);
            Destroy(collision.gameObject);  // Destroy the balloon
            Destroy(gameObject);  // Destroy the arrow
        }
        else if (collision.CompareTag("Cat"))
        {
            // Optionally destroy the Cat object if hit
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
