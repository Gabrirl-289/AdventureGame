using UnityEngine;

public class DoorSetActive : MonoBehaviour
{
    public void OpenDoor() {
        gameObject.SetActive(false);
    }
}
