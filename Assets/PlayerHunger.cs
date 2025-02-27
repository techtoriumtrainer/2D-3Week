using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHunger : MonoBehaviour
{
    public float maxHunger = 100f; // Maximum hunger value
    public float hungerDecreaseRate = 1f; // Rate at which hunger decreases over time
    private float currentHunger; // Current hunger value

    void Start()
    {
        currentHunger = maxHunger; // Initialize hunger to full at start
    }

    void Update()
    {
        // Decrease hunger over time
        currentHunger -= hungerDecreaseRate * Time.deltaTime;
        currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger); // Clamp hunger within 0 to maxHunger

        // Check if hunger has reached zero
        if (currentHunger <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("goodFood"))
        {
            EatGoodFood();
            Destroy(other.gameObject); // Destroy the good food object
        }
        else if (other.CompareTag("badFood"))
        {
            EatBadFood();
            Destroy(other.gameObject); // Destroy the bad food object
        }
    }

    public void EatGoodFood()
    {
        // Increase hunger by 25 when eating good food
        currentHunger += 25f;
        currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger); // Clamp hunger within 0 to maxHunger
    }

    public void EatBadFood()
    {
        // Decrease hunger by 20 when eating bad food
        currentHunger -= 20f;
        currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger); // Clamp hunger within 0 to maxHunger
    }

    public float GetCurrentHunger()
    {
        return currentHunger;
    }

    private void Die()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
