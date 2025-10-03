using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Vector2 boxSize;
    public LayerMask boxLayer;

    public KeyCode interact;
    private void Update()
    {
        if (Input.GetKeyDown(interact))
        {
            InteractWith();
        }
    }
    public void InteractWith()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.zero, 1, boxLayer);
        
        if (hit && hit.collider.TryGetComponent(out Interactable interactible))
        {
            interactible.onInteract.Invoke();
        }
    }

        private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, boxSize);
    }

    
}
