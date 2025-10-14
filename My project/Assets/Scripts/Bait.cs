using Pathfinding;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public TextMeshProUGUI ammotext;
    public AIDestinationSetter ai;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ammotext.text = "ammo: " + ammo.ToString();
        //if (ammo >= 1 && Input.GetKeyDown(Throw))
        //{

        //    Instantiate(Projectile, player.transform.position, player.transform.rotation);
        //    Debug.Log("Bait Thrown");
        //    ammo--;
        //}
        ammotext.text = "ammo: " + ammo.ToString();
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        
        if (ctx.performed && ammo >= 1)
        {
            Instantiate(Projectile, player.transform.position, player.transform.rotation);
            Debug.Log("Bait Thrown");
            ammo--;
            
        }
    }
    //private IEnumerator enumerator()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //}
}
