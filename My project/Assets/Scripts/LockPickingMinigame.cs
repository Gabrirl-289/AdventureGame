using System;
using UnityEngine;

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
        throw new NotImplementedException();
    }

    private void Pick()
    {
        pickposition += Input.GetAxisRaw("Horizontal") * Time.deltaTime * pickSpeed;
    }
}
