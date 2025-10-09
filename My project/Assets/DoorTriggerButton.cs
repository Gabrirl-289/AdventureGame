using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField] private DoorAnimated door;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            door.OpenDoor();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            door.CloseDoor();
        }
    }
}
