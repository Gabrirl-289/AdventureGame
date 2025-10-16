using UnityEngine;

public class cardScript : MonoBehaviour
{
    // Reference to the player having the card
    public static bool hasCard = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasCard = true;
            Debug.Log("Card picked up!");
            // Optionally, destroy the card object after pickup
            Destroy(gameObject);
        }
    }
}
