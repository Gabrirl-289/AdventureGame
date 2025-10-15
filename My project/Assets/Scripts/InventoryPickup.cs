using UnityEngine;

public class InventoryPickup : MonoBehaviour
{
    
    private Inventory inventory;
    public GameObject itemButton;

    public AudioSource audioSource;
    private void Start()
    {
     //   audioSource = GetComponent<AudioSource>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                {
                    if (inventory.isFull[i] == false)
                    {
                        inventory.isFull[i] = true;
                        Instantiate(itemButton, inventory.slots[i].transform, false);
                        Destroy(gameObject);
                        audioSource.Play();
                        break;
                    }
                }
            }
        }
    }
}
