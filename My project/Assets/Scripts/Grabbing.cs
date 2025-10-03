using UnityEngine;

public class Grabbing : MonoBehaviour
{
    public float grabRange = 3f;
    public KeyCode grabKey = KeyCode.E;
    public GameObject grabbedObject;

    void Update()
    {
        if (Input.GetKeyDown(grabKey))
        {
            if (grabbedObject == null)
            {
                // Try to grab
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, grabRange);
                if (hit.collider != null && hit.collider.CompareTag("weight"))
                {
                    grabbedObject = hit.collider.gameObject;
                    grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; // Disable physics while holding
                    grabbedObject.transform.SetParent(transform);
                    grabbedObject.transform.localPosition = new Vector3(1.5f, 0, 0); // Hold to the right of player
                }
            }
            else
            {
                // Place object
                grabbedObject.transform.SetParent(null);
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; // Re-enable physics
                grabbedObject.transform.position = transform.position + transform.right * 2f; // Place 2 units to the right
                grabbedObject = null;
            }
        }
    }
}
