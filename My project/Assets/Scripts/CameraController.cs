using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float speed = 5.0f;
    public Vector3 offset; //= new Vector3(0, 0, -10);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, speed * Time.deltaTime);
    }
}
