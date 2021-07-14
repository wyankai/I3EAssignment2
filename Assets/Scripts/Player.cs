/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)
[Adapted from Mr Elyas's Script]

Name of Class: Player

Description of Class: This class will control the movement and actions of a 
                        player avatar based on user input.

Date Created: 20/06/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody myRigidbody;

    [SerializeField]
    private float interactionDistance = 3;

    // The distance this player will travel per second.
    private float moveSpeed = 3;

    // Speed of Camera Rotation.
    // Solve the problem where the camera overturn at the start of the game(Part 1)
    private float rotationSpeed = 100;

    //To check if the player is on the ground
    private bool onGround = true;

    // The camera attached to the player model.
    [SerializeField]
    private Camera playerCamera;

    // This is for us to check the state while debugging
    private string currentState;
    private string nextState;

    //To attach the player's animator
    public Animator animator;

    //Check if player is chatting with an NPC or not
    public bool Chatting = false;

    public GameObject NPC;
    public GameObject gate;
    public int jumpForce = 7;

    public GameObject jumpAudio;
    public GameObject jumpLandAudio;
    public GameObject doorAudio;
    private AudioSource footstep;

    // Start is called before the first frame update
    void Start()
    {
        nextState = "Idle";
        footstep = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nextState != currentState)
        {
            SwitchState();
        }
        //Check for rotation of the character and the camera
        CheckRotation();

        //Check if space button is being pressed
        CheckJump();

        //Raycast
        InteractionRaycast();

        //For checking values for the animation
        animator.SetBool("onGround", onGround);
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetBool("Chatting", Chatting);
    }

    // Sets the current state of the player and starts the correct coroutine.
    private void SwitchState()
    {
        StopCoroutine(currentState);

        currentState = nextState;
        StartCoroutine(currentState);
    }

    //Raycast for the character
    private void InteractionRaycast()
    {
        //Draw line
        Debug.DrawLine(playerCamera.transform.position, playerCamera.transform.position + playerCamera.transform.forward * interactionDistance);

        //Layer in which raycast can detect
        int doorLayerMask = 1 << LayerMask.NameToLayer("Door");
        int npcLayerMask = 1 << LayerMask.NameToLayer("NPC");
        int bagLayerMask = 1 << LayerMask.NameToLayer("Bag");
        int bagStandLayerMask = 1 << LayerMask.NameToLayer("Bag Stand");
        int gateLockedLayerMask = 1 << LayerMask.NameToLayer("GateLocked");

        RaycastHit hitInfo;

        //Door
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, interactionDistance, doorLayerMask))
        {
            //If my ray hits something, print out the name of the object
            Debug.Log("Door is being detected!");

            if (Input.GetKeyDown(KeyCode.E))
            {
                hitInfo.transform.GetComponent<Door>().Open();
                GameObject doorOpenAudio = Instantiate(doorAudio, transform.position, Quaternion.identity, null);
            }

        }

        //For first level
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, interactionDistance, bagLayerMask))
        {
            //If my ray hits something, print out the name of the object
            Debug.Log("Bag is being activated!");

            if (Input.GetKeyDown(KeyCode.E))
            {
                hitInfo.transform.GetComponent<BagPuzzle>().Collect();
            }

        }

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, interactionDistance, bagStandLayerMask))
        {
            //If my ray hits something, print out the name of the object
            Debug.Log("Bag Stand is being activated!");

            if (Input.GetKeyDown(KeyCode.E))
            {
                hitInfo.transform.GetComponent<BagStand>().Check();
            }
        }

        //For Gate Locked
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, interactionDistance, gateLockedLayerMask))
        {
            Debug.Log("Player is interacting with the Gate");
            //Let NPC Script know that player is in range
            hitInfo.transform.GetComponent<GateLocked>().PlayerInRange();
        }
        else
        {
            gate.GetComponent<GateLocked>().PlayerNotInRange();
        }

        //For NPC
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, interactionDistance, npcLayerMask))
        {
            Debug.Log("Player is interacting with the NPC");
            //Let NPC Script know that player is in range
            hitInfo.transform.GetComponent<NPC>().PlayerInRange();
        }
        else
        {
            NPC.GetComponent<NPC>().PlayerNotInRange();
        }
    }

    //Sets 
    public void StopMoving()
    {
        Chatting = true;
    }
    public void MoveAgain()
    {
        Chatting = false;
    }

    //Check and allow the player to jump
    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround && !Chatting)
        {
            myRigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            onGround = false;
            GameObject landAudio = Instantiate(jumpAudio, transform.position, Quaternion.identity, null);
        }
    }

    //Allow player to jump if they land on the ground.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
            GameObject landAudio = Instantiate(jumpLandAudio, transform.position, Quaternion.identity, null);
        }
        if (collision.gameObject.tag == "Grass")
        {
            onGround = true;
        }
    }

    // Checks and handles rotation of the camera and player
    private void CheckRotation()
    {
        if (Chatting == false)
        {
            Vector3 playerRotation = transform.rotation.eulerAngles;
            playerRotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(playerRotation);

            Vector3 cameraRotation = playerCamera.transform.rotation.eulerAngles;
            cameraRotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            playerCamera.transform.rotation = Quaternion.Euler(cameraRotation);
        }
        else
        {
            Debug.Log("Rotation disabled until Chatting is done");
        }
    }

    // Checks and handles movement of the player
    private bool CheckMovement()
    {
        CheckRun();
        if (Chatting == true)
        {
            return false;
        }
        Vector3 newPos = transform.position;

        Vector3 xMovement = transform.right * Input.GetAxis("Horizontal");
        Vector3 zMovement = transform.forward * Input.GetAxis("Vertical");

        Vector3 movementVector = xMovement + zMovement;


        if (movementVector.sqrMagnitude > 0)
        {
            movementVector *= moveSpeed * Time.deltaTime;
            newPos += movementVector;

            transform.position = newPos;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void CheckRun()
    {
        // If left shift is being pressed, run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 6;
        }
        else
        {
            moveSpeed = 3;
        }
    }

    private void Footsteps()
    {
        footstep.Play();
    }

    //Idle State
    private IEnumerator Idle()
    {
        while(currentState == "Idle")
        {
            if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                nextState = "Moving";
            }
            yield return null;
        }
    }

    //Moving State
    private IEnumerator Moving()
    {
        while (currentState == "Moving")
        {
            
            if (!CheckMovement())
            {
                nextState = "Idle";

            }
            
            yield return null;
        }
    }
}
