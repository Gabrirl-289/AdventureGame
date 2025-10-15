using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public  Inventory inventory;
    private void OnTriggerEnter2D(Collider2D collision)
    
    {
        if (collision.CompareTag("Player") && System.Array.TrueForAll(inventory.isFull, isfull => isfull))
        {
            SceneManager.LoadScene("Win");
        }
    }
}
