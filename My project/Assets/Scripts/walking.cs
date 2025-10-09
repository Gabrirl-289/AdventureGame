using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class  PlayerController : MonoBehaviour
{
    private Vector3 MoveDirection;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // get horiz and vert inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // update movemetn direction
        MoveDirection = new Vector3(horizontal, 0, vertical);



        if (MoveDirection == Vector3.zero)
        {
           animator.SetFloat("Speed", 0);
        }
        else
        {
            animator.SetFloat("Speed", 1);
        }
        
    }


}
public class Walking
{

}
