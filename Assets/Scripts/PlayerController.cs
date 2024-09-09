using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    Vector2 input;
    [SerializeField] float jumpForce;
    [SerializeField] float speed;
    [SerializeField] Stats currentHealth;
    [SerializeField] Stats maxHealth;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponentInChildren<Rigidbody>();
        currentHealth.amount = maxHealth.amount;
    }

    private void OnEnable()
    {
        InputManager.controls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        input = InputManager.controls.Human.Movement.ReadValue<Vector2>();
        
        animator.SetFloat("Speed", input.magnitude);

        
    }

    private void FixedUpdate()
    {
        var newInput = GetCameraBasedInput(input, Camera.main);

        var newVelocity = new Vector3(newInput.x * speed, rb.velocity.y, newInput.z * speed);

        rb.velocity = newVelocity;

        if (newVelocity != Vector3.zero)
        {
            RotatePlayerModel(newVelocity);
        }
    }

    Vector3 GetCameraBasedInput(Vector2 input, Camera cam)
    {
        Vector3 camRight = cam.transform.right;
        camRight.y = 0;
        camRight.Normalize();

        Vector3 camForward = cam.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        return input.x * camRight + input.y * camForward;
    }

    private void RotatePlayerModel(Vector3 dir)
    {
        dir.y = 0;
        animator.transform.forward = dir;
    }


    public void OnJump()
    {
        rb.AddForce(0.0f, jumpForce, 0.0f, ForceMode.Impulse);
        animator.SetTrigger("Jump");
    }


}

