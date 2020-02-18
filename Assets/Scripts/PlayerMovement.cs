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
    private float range;
    public bool underObject;
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
 
    Vector3 velocity;
    bool isGrounded;

    [SerializeField]
    private bool hasPotatoGun;
    [SerializeField]
    private int currentAmmo;
    [SerializeField]
    private int maxAmmo;
    [SerializeField]
    private Rigidbody projectile;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private GameObject potatoGun;
    [SerializeField]
    private float gunForce;



    // Update is called once per frame

    void Start()
    {
        originalHeight = controller.height;
        originalSpeed = speed;
    }
    void Update()
    {

        CrouchDetect();
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
        else if(Input.GetMouseButtonDown(0))
        {        
              
            if(hasPotatoGun)
            {
                Shoot();
            }
    
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
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
            if(!underObject)
            {
                speed = originalSpeed;
                // controller.height = Mathf.Lerp(controller.height, originalHeight, smoothTime);   
                controller.height = originalHeight;
            }
      
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ff");
        if (other.gameObject.CompareTag("PotatoGun"))
        {
            hasPotatoGun = true;
            Destroy(other.gameObject);
            potatoGun.SetActive(true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other != null)
        {
            underObject = true;
        }    
    }

    void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            underObject = false;
        }
    }

    public void WriteInstructions()
    {
        // fungus shit 
    }


    public void StoryLineInfo()
    {
        // fungus shit 
    }

    void Shoot()
    {
        if(currentAmmo > 0)
        {
            currentAmmo--;
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectile, shootPoint.position, shootPoint.rotation) as Rigidbody;
            projectileInstance.AddForce(shootPoint.forward * gunForce);

        }
        else
        {
            return;
        }
    
    }


}

