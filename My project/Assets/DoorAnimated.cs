using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimated : MonoBehaviour
{
    private Animator animator;
    public GameObject doorcolider;
    private bool closed = false;
    private void Awake()
    {
       animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        animator.SetBool("Open", true);
        closed = true;
    }

    public void CloseDoor()
    {
        animator.SetBool("Open", false);
        closed = false;
    }

    public void Update()
    {
        if (closed == true)
        {
            doorcolider.SetActive(false);
        }
        else if (closed == false) { 
        doorcolider.SetActive(true);
        }
    }
}
