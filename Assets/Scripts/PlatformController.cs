using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatformController : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
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
    }
}