using UnityEngine;

public class MirrorRotator : MonoBehaviour
{
    public float rotationSpeed = 90f; // Degrees per second

    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
    }
}
