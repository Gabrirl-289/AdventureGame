using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField] private DoorSetActive door;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            door.OpenDoor();
        }
    }
}
