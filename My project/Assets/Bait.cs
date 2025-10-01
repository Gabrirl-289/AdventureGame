using UnityEngine;

public class Bait : MonoBehaviour
{
    public KeyCode Throw = KeyCode.F;
    public GameObject Projectile;
    public Transform ProjectileTransform;
    public bool canFire;
    private float timer;
    public float Timebetween;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Throw))
        {
           Instantiate(Projectile, player.transform.position, player.transform.rotation);
            Debug.Log("Bait Thrown");
        }
    }
}
