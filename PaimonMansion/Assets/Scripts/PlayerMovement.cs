using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 6f;
    public float runSpeed = 11f;
    public float gravityMultiplier;
    float gravity = -9.81f;
    float speed;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    CharacterController controller;
    Vector3 velocity;
    bool isGrounded;
    Vector3 movement = Vector3.zero;

    [HideInInspector]
    public bool isRunning = false;

    [HideInInspector]
    public float runMultiplier;

    private void Awake()
    {
        runMultiplier = runSpeed / walkSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = walkSpeed;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
            speed = runSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            speed = walkSpeed;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement = transform.right * x + transform.forward * z;

        Physics.SyncTransforms();
        controller.Move(movement * speed * Time.deltaTime);

        velocity.y += gravity * gravityMultiplier * Time.deltaTime;

        Physics.SyncTransforms();
        controller.Move(velocity * Time.deltaTime);
    }

    public Vector3 GetMovement()
    {
        return movement;
    }
}
