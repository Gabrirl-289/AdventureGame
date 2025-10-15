using UnityEngine;

public class DoorInteractAutomatic : MonoBehaviour

{
    [SerializeField] private GameObject doorGameObjectA;
    private IDoor door;

    private void Awake()
    {
        door = doorGameObjectA.GetComponent<IDoor>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<BoxCollider2D>() != null)
        {
            //Player entered collider
            door.OpenDoor();
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<BoxCollider2D>() != null)
        {
            //Player exited collider
            door.CloseDoor();
        }
    }
}
