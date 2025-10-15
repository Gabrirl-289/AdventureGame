using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimated : MonoBehaviour, IDoor
{
    private Animator animator;
    public GameObject doorcolider;
    private bool isOpen = false;
    private void Awake()
    {
       animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        isOpen = true;
        animator.SetBool("Open", true);
    }

    public void CloseDoor()
    {
        isOpen = false;
        animator.SetBool("Open", false);
    }

    public void PlayOpenFailAnim()
    {
       doorAnimated.SetTrigger("OpenFail");
    }

    public void Update()
    {
        if (isOpen == true)
        {
            doorcolider.SetActive(false);
        }
        else if (isOpen == false) { 
        doorcolider.SetActive(true);
        }
    }

    public void ToggleDoor()
    {
        throw new System.NotImplementedException();
    }
}
