using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;

    private DoorAnimated doorAnimated;

    private void Awake()
    {
        doorAnimated = GetComponent<DoorAnimated>();
    }

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        doorAnimated.OpenDoor();
    }

    public void PlayOpenFailAnim()
    {
        doorAnimated.PlayOpenFailAnim();
    }
}
