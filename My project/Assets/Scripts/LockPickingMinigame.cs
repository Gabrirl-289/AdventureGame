using System;
using UnityEngine;
//i will focus on something else for now
public class LockPickingMinigame : MonoBehaviour
{
    [SerializeField]float pickSpeed = 3f;
    float pickposition;
    public float Pickposition
    {
        get { return pickposition; }
        set 
        { 
            pickposition = value;
        pickposition = Mathf.Clamp(pickposition, 0, 1f);
        }
    }
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    float cyllinderposition;
    public float Cylinderposition
    {
        get { return cyllinderposition; }
        set { 
            cyllinderposition = value;
            cyllinderposition = Mathf.Clamp(cyllinderposition, 0, 1f);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
   private void Update()
    {
        Pick();
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("PickPosition", pickposition);
    }

    private void Pick()
    {
        pickposition += Input.GetAxisRaw("Horizontal") * Time.deltaTime * pickSpeed;
    }
}
