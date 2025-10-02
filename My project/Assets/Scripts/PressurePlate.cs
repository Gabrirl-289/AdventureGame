using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("Player stepped on the pressure plate.");
            // Add logic to activate whatever the pressure plate is connected to
        }
    }
}
