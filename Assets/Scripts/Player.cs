/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)
[Adapted from Mr Elyas's Script]

Name of Class: DemoPlayer

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

    // The distance this player will travel per second.
    [SerializeField]
    private float moveSpeed;

    // Speed of Camera Rotation.
    // Solve the problem where the camera overturn at the start of the game(Part 1)
    private float rotationSpeed = 0;

    //To check if the player is on the ground
    private bool onGround = true;

    // The camera attached to the player model.
    [SerializeField]
    private Camera playerCamera;

    // This is for us to check the state while debugging
    [SerializeField]
    private string currentState;
    [SerializeField]
    private string nextState;

    // Start is called before the first frame update
    void Start()
    {
        nextState = "Idle";
    }

    // Update is called once per frame
    void Update()
    {
        if(nextState != currentState)
        {
            SwitchState();
        }

        CheckRotation();
        CheckJump();
    }

    // Sets the current state of the player and starts the correct coroutine.
    private void SwitchState()
    {
        StopCoroutine(currentState);

        currentState = nextState;
        StartCoroutine(currentState);
    }

    //Check and allow the player to jump
    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            myRigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            onGround = false;
        }
    }

    //Allow player to jump if they land on the ground.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    // Checks and handles rotation of the camera and player
    private void CheckRotation()
    {
        // Solve the problem where the camera overturn at the start of the game(Part 1)
        if (rotationSpeed == 0){
            System.Threading.Thread.Sleep(100);
            rotationSpeed = 72;
        }
        Vector3 playerRotation = transform.rotation.eulerAngles;
        playerRotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(playerRotation);

        Vector3 cameraRotation = playerCamera.transform.rotation.eulerAngles;
        cameraRotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        playerCamera.transform.rotation = Quaternion.Euler(cameraRotation);
    }

    // Checks and handles movement of the player
    private bool CheckMovement()
    {
        Vector3 newPos = transform.position;

        Vector3 xMovement = transform.right * Input.GetAxis("Horizontal");
        Vector3 zMovement = transform.forward * Input.GetAxis("Vertical") ;

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
