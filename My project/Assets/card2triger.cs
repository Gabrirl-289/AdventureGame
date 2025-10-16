using UnityEngine;

public class card2triger : MonoBehaviour
{
    // Reference to the player having the card
    public static bool hasCard2 = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasCard2 = true;
            Debug.Log("Card picked up!");
            // Optionally, destroy the card object after pickup
            Destroy(gameObject);
        }
    }
}
