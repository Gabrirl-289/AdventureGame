using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObjectA;

    private IDoor doorA;

    private void Awake()
    {
        doorA = doorGameObjectA.GetComponent<IDoor>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            doorA.OpenDoor();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            doorA.CloseDoor();
        }
    }
}
