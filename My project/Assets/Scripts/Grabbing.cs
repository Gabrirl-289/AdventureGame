using UnityEngine;

public class Grabbing : MonoBehaviour
{
    [SerializeField]
    private Transform grabPoint;
    
    [SerializeField]
    private Transform rayPoint;
    
    [SerializeField]    
    private float raydistance = 2.5f;
    private GameObject grabbedObject;
    private int layerIndex;
    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Weight");
    }
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, raydistance);
        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (Input.GetKeyDown(KeyCode.E) && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                grabbedObject.transform.SetParent(null);
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                grabbedObject = null;
            }
        }
        Debug.DrawRay(rayPoint.position, transform.forward * raydistance, Color.red);

    }
    private void OnDrawGizmos()
    {
       // Gizmos.DrawSphere(transform.position, 2.5f); // Draw a small sphere at the origin // Draw the grab range
    }
}
