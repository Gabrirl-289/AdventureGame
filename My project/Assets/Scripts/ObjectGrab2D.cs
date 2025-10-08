using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectGrab2D : MonoBehaviour
{
    public float grabDistance = 1.5f;
    public Transform holdPoint;
    public KeyCode grabKey = KeyCode.E;
    public LayerMask weightLayer; // Drag your "Weight" layer here in Inspector

    private GameObject heldObject = null;

    void Update()
    {
        //if (Input.GetKeyDown(grabKey))
        //{
        //    if (heldObject == null)
        //        TryGrabObject();
        //    else
        //        ReleaseObject();
        //}

        if (heldObject != null)
        {
            heldObject.transform.position = holdPoint.position;
        }
    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            print("somehting1");
            if (heldObject == null)
                TryGrabObject();
        }
        else if (ctx.canceled)
        {
            print("something2");
            if (heldObject != null)
                ReleaseObject();
        }
    }

    void TryGrabObject()
    {
        // Cast a ray in the 4 main directions (up, down, left, right)
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

        foreach (Vector2 dir in directions)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, grabDistance, weightLayer);
            Debug.DrawRay(transform.position, dir * grabDistance, Color.red, 1f);

            if (hit.collider != null)
            {
                GameObject target = hit.collider.gameObject;

                if (target.CompareTag("weight") || target.layer == LayerMask.NameToLayer("Weight"))
                {
                    heldObject = target;
                    Debug.Log("Grabbed: " + heldObject.name);

                    Rigidbody2D rb = heldObject.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.linearVelocity = Vector2.zero;
                        rb.isKinematic = true;
                    }

                    return; // Stop after grabbing one object
                }
            }
        }

        Debug.Log("No grabbable object found.");
    }

    void ReleaseObject()
    {
        if (heldObject != null)
        {
            Rigidbody2D rb = heldObject.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.isKinematic = false;

            Debug.Log("Released: " + heldObject.name);
            heldObject = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * grabDistance);
    }
}
