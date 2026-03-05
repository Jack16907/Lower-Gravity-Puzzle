using UnityEngine;
using UnityEngine.SceneManagement; // Essential for scene-based logic

public class GravityChangeScript : MonoBehaviour
{
    [Header("Gravity Settings")]
    public float newGravityScale = 1.0f;
    public string targetSceneName = "Level2"; // Change this to your scene's name

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        // Subscribe to the scene loading event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Always unsubscribe to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // This is called automatically every time a scene finishes loading
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetSceneName)
        {
            ApplyGravityChange();
        }
    }

    void ApplyGravityChange()
    {
        if (rb != null)
        {
            rb.gravityScale = newGravityScale;
            Debug.Log("Gravity modified for: " + SceneManager.GetActiveScene().name);
        }
    }
}
