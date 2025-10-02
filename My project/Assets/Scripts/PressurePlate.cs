using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool pressured = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(pressured);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            pressured = true;
            Debug.Log("Player stepped on the pressure plate.");
            // Add logic to activate whatever the pressure plate is connected to
        }
        else
        {
            pressured = false;
        }
    }
}
