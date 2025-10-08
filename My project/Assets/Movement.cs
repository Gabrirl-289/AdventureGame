using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
//using UnityEditor;
//using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class Movement : MonoBehaviour
{
    public float distanceBetween;
    //public GameObject Enemy;
    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S, Jump = KeyCode.Space, sprint = KeyCode.LeftShift, slowdown = KeyCode.LeftControl;
    public float speed = 10, jumpHeight = 15;
    private float distance;
    private Rigidbody2D _rb;
    public bool looking = true;
    private Camera Cam;
    public Bait baitSctipt;
    public TextMeshProUGUI gainammo;
    public PlayableDirector baitPlusOne;
    public bool isSprinting;
    public bool isCrouching;

    public Vector2 _movement;
    public Vector2 direction;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
      Cam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
        gainammo.text = "+1 Bait!";
        animator = GetComponent<Animator>();
        
    }
    //lit allows light change
    //default dont follow light
    // Update is called once per frame
    void Update()
    {
        //Input.GetKey(); is for HOLDING a key
        //Input.GetKeyDown(); is for PRESSING a key
        //Input.GetKeyUp(); is for RELEASING a key

        //distance = Vector2.Distance(transform.position, Enemy.transform.position);
        //if (Input.GetKey(sprint))
        //{
        //    speed = 15;
        //}
        //if (Input.GetKeyUp(sprint))
        //{
        //    speed = 10;
        //}
        //if (Input.GetKey(slowdown))
        //{
        //    speed = 5;
        //}
        //if (Input.GetKeyUp(slowdown))
        //{
        //    speed = 10;
        //}
        
        //if (Input.GetKey(left)) //chek for the player holding down the left button
        //{
        //    _rb.linearVelocity = Vector2.left * speed; //get the component to the ri
        //}

        //if (Input.GetKey(right)) // check to be holding down the right button
        //{
        //    GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * speed;
        //}

        //if (Input.GetKey(up)) //chek for the player holding down the up button
        //{
        //    GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * speed;
        //}

        //if (Input.GetKey(down)) //chek for the player holding down the up down button
        //{
        //    GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed;
        //}

        //if (Input.GetKeyDown(Jump))
        //{
        //    GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * jumpHeight;
        //}

        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    GetComponent<Rigidbody2D>().Gravity Scale *= -1;
        //}
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Baitammo")
        {
            baitSctipt.ammo++;
            Destroy(collision.gameObject);
            baitPlusOne.Play();


        }
        if (collision.gameObject.tag == "Enemy")
        {
            _rb.linearVelocity = Vector3.zero;
            _rb.angularVelocity = 0.0f;
            //SceneManager.LoadScene("gameover");
        }

    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>();
        animator.SetBool("walking", true);

        if (ctx.ReadValue<Vector2>() != Vector2.zero)
        {
            direction = ctx.ReadValue<Vector2>();
            animator.SetBool("walking", false);
        }

    //    if (ctx.ReadValue<Vector2>() != Vector2.zero)
     //   {
    //        animator.SetBool("walking", false);
    //    }

    }

    public void Crouch(InputAction.CallbackContext ctx)
    {
        print(ctx.phase);

        if(isSprinting)
        {
            return;
        }

        if (ctx.performed)
        {
            print("Crouch");
            isCrouching = true;
            speed = 5;
        }
        else
        {
            print("Not Crouched");
            isCrouching = false;
            speed = 10;
        }
    }

    public void Sprint(InputAction.CallbackContext ctx)
    {
        print(ctx.phase);
        if (isCrouching)
        {
            return;
        }

        if (ctx.performed)
        {
            print("Sprinting");
            isSprinting = true;
            speed = 15;
        }
        else
        {
            print("Not Sprinting");
            isSprinting = false;
            speed = 10;
        }
    }

    public void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_movement.x * speed, _movement.y * speed);
        Vector3 MousePos = (Vector2)Cam.ScreenToWorldPoint(Input.mousePosition);
        float angledRad = Mathf.Atan2(MousePos.y - transform.position.y, MousePos.x - transform.position.x);
        float angledDeg = (180 / Mathf.PI) * angledRad - 90; //offset this by 90 degrees
        transform.rotation = Quaternion.Euler(0, 0, angledDeg);
        Debug.DrawLine(transform.position, MousePos, Color.red);
    }
}


