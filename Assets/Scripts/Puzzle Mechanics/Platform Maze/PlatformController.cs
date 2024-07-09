using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlatformController : Interactable
{
    [SerializeField]
    private GameObject platform;

    [SerializeField]
    private float maxRotationX = 45.0f;
    [SerializeField]
    private float maxRotationZ = 45.0f;
    [SerializeField]
    private float speed = 5.0f;

    private float xRotation;
    private float zRotation;

    private bool playing = false;

    InputActions inputActions; //this refers to the player input, which we can use to access interact key (E or left click)

    FirstPersonController firstPersonController;

    [SerializeField]
    private Camera playerPOVCamera;

    [SerializeField]
    private Camera platformGameCamera;

    private void Awake()
    {
        inputActions = new InputActions(); //initializes player input
    }

    protected override void Interact()
    {
        playing = true;
        //shift cameras
        //disable player actions
        firstPersonController.playerCanMove = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playing == true)
        {
            xRotation = Input.GetAxis("Vertical");
            zRotation = -Input.GetAxis("Horizontal");

            Vector3 currentRot = platform.transform.localEulerAngles;

            // Convert angles to a range of -180 to 180 degrees
            if (currentRot.x > 180) currentRot.x -= 360;
            if (currentRot.z > 180) currentRot.z -= 360;

            float targetRotationX = Mathf.Clamp(currentRot.x + xRotation * speed * Time.deltaTime, -maxRotationX, maxRotationX);
            float targetRotationZ = Mathf.Clamp(currentRot.z + zRotation * speed * Time.deltaTime, -maxRotationZ, maxRotationZ);

            platform.transform.localEulerAngles = new Vector3(targetRotationX, currentRot.y, targetRotationZ);

            if (inputActions.Player.Interact.IsPressed()) //if player presses interact key
            {
                Debug.Log("Player interacted with the object");
                playing = false;
                //shift camera back
                //enable player actions
                firstPersonController.playerCanMove = true;
            }
        }
    }

    public void OnEnable()
    {
        inputActions.Player.Enable(); //here Player is referring to the name of the action map in Unity
    }

    public void OnDisable()
    {
        inputActions.Player.Disable(); //here Player is referring to the name of the action map in Unity
    }
}