using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    PlayerInput input;
    [SerializeField] float jumpForce;
    [SerializeField] float speed;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponentInChildren<Rigidbody>();
        input = GetComponentInChildren<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMovement()
    {
        
    }

    public void OnJump()
    {
        rb.AddForce(0.0f, jumpForce, 0.0f, ForceMode.Impulse);
        animator.SetTrigger("Jump");
    }


}

