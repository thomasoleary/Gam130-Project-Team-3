using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraDetection : MonoBehaviour
{


    public GameObject playerObject;

    public GameObject light1, light2;
    public Light camLight;
    public Color origColor;
    public Color detectColor;


    public enum CamState
    {
        lookingLeft,
        LookingRight
    }
    public CamState cameraState;
    [SerializeField]
    private GameObject camLeftPos;
    [SerializeField]
    private GameObject camRightPos;

    [SerializeField]
    private float camRotationSpeed;
    [SerializeField]
    private float camTurnDelay;
    [SerializeField]
    private float detectionTimeCount;

    bool camDetect = false;
    bool InsideViewrange = false;
    bool IsBeingDetected = false;



    
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    void Update()
    {
       
        CameraChecker();

        if (InsideViewrange)
        {
            HandleRaycast();
        }

    }
    void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

        if(player != null)
        {
            InsideViewrange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

        if (player != null)
        {
            InsideViewrange = false;
            IsBeingDetected = false;
        }
    }




    private void HandleRaycast()
    {
     
        RaycastHit hit;

        if (Physics.Raycast(transform.position, (playerObject.transform.position - transform.position), out hit))
        {

            if (hit.collider.tag == "Player")
            {
                
                Debug.DrawRay(transform.position, (playerObject.transform.position - transform.position), Color.red);
                IsBeingDetected = true;
                camDetect = true;       
                StartCoroutine(CheckDetection());
            }
            else
            {
                IsBeingDetected = false;
                StopCoroutine(CheckDetection());
            }

        }
    }

    void DetectedPlayer()
    {
        if (IsBeingDetected)
        {
            SceneManager.LoadScene("Stealth level");
        }
        else
        {
            camLight.color = origColor;    
            light1.SetActive(true);
            light2.SetActive(false);
            camDetect = false;
            return;
        }
  
    }

    public void CameraChecker()
    {
        if(camLeftPos != null && !camDetect)
        {
            if (cameraState == CamState.lookingLeft)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, camLeftPos.transform.rotation, camRotationSpeed * Time.deltaTime);
                StartCoroutine(CamRotateRight());
            }
            else if (cameraState == CamState.LookingRight)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, camRightPos.transform.rotation, camRotationSpeed * Time.deltaTime);
                StartCoroutine(CamRotateLeft());
            }

        }
    
    }

    IEnumerator CamRotateLeft()
    {
        yield return new WaitForSeconds(camTurnDelay);
        cameraState = CamState.lookingLeft;
    }

    IEnumerator CamRotateRight()
    {
        yield return new WaitForSeconds(camTurnDelay);
        cameraState = CamState.LookingRight;
    }


    IEnumerator CheckDetection()
    {  
        light1.SetActive(false);
        light2.SetActive(true);
        camLight.color = detectColor;
        yield return new WaitForSeconds(detectionTimeCount);       
        DetectedPlayer();
    }

}
