using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isPressed = false;
    public Sprite unpressedSprite;
    public Sprite pressedSprite;

    public GameObject objectToActivate; // Like a door or bridge

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr && unpressedSprite)
            sr.sprite = unpressedSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Weight"))
        {
            isPressed = true;
            if (sr && pressedSprite)
                sr.sprite = pressedSprite;

            Debug.Log("Pressure plate pressed!");
            if (objectToActivate)
                objectToActivate.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Weight"))
        {
            isPressed = false;
            if (sr && unpressedSprite)
                sr.sprite = unpressedSprite;

            Debug.Log("Pressure plate released!");
            if (objectToActivate)
                objectToActivate.SetActive(true);
        }
    }
}
