using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Settings for Player Ship")]
    [Tooltip("Controlling Speed of Player Ship")]
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;

    [Header("Screen Position Based Tuning")]
    [SerializeField] float positionPitchFactor = 10f;
    [SerializeField] float positionYawFactor = 10f;

    [Header("Player Input Based Tuning")]
    [SerializeField] float controlPitchFactor = 10f;
    [SerializeField] float controlRollFactor =10f;
    [SerializeField] GameObject[] lasers;

    float xThrow,yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        processMovement();
        processRotation();
        processFiring();
    }

    void processMovement()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float xRawPosition = transform.localPosition.x + xOffset;
        float xNewPosition = Mathf.Clamp(xRawPosition, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float yRawPosition = transform.localPosition.y + yOffset;
        float yNewPosition = Mathf.Clamp(yRawPosition, -yRange, yRange);

        transform.localPosition = new Vector3(xNewPosition, yNewPosition, transform.localPosition.z);
    }
    
    void processRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow *controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControl;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch ,yaw , roll);
    }

    void processFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            SetActiveLasers(true);
        }
        else
        {
            SetActiveLasers(false);
        }
    }

    void SetActiveLasers(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
           emissionModule.enabled = isActive;
        }
    }
}
