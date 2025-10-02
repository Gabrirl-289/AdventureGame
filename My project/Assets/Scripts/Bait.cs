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
    public int ammo = 5;
    public int bulletDeathTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ammo >= 1 && Input.GetKeyDown(Throw))
        {
           Instantiate(Projectile, player.transform.position, player.transform.rotation);
            Debug.Log("Bait Thrown");
            StartCoroutine(bulletDeath());
            ammo--;
        }
        
    }
    System.Collections.IEnumerator bulletDeath()
    {
        yield return new WaitForSeconds(bulletDeathTime);
        Destroy(Projectile);
    }
}
