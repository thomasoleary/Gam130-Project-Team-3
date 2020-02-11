using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [SerializeField]
    private bool isCrouching = false;
    [SerializeField]
    private float crouchHeight;
    [SerializeField]
    private float crouchSpeed = 6f;
    [SerializeField]
    private float originalHeight;
    [SerializeField]
    private float originalSpeed;
    [SerializeField]
    private float smoothTime;
    [SerializeField]
    private float currentVelocity;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame

    void Start()
    {
        originalHeight = controller.height;
        originalSpeed = speed;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x) + (transform.forward * z);

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = true;
        }
        else if(Input.GetKeyUp(KeyCode.C))
        {
            isCrouching = false;
        }




        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void FixedUpdate()
    {
        CrouchDetect();
    }

    void CrouchDetect()
    {
        if(isCrouching)
        {
            speed = crouchSpeed;
            controller.height = Mathf.Lerp(controller.height, crouchHeight, smoothTime);
        }
        else
        {
            speed = originalSpeed;
            controller.height = Mathf.Lerp(controller.height, originalHeight, smoothTime);   

        }
    }


}

