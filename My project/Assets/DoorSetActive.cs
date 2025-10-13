using UnityEngine;

public class DoorSetActive : MonoBehaviour, IDoor
{
    public void OpenDoor() {
        gameObject.SetActive(false);
    }

    public void CloseDoor()
    {
        gameObject.SetActive(true);
    }
}
