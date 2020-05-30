using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{

    [Header("General")]
	[Tooltip("In ms^-1")] [SerializeField] float speed = 15f; //fixed speed the player can move
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 4f;

    [Header("Screen Position Controls")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Input Throw Controls")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;
    bool isControlEnabled = true;
   

    // Update is called once per frame
    void Update()
    {

        if (isControlEnabled)
        {
            ProcessRotation();
            ProcessTranslation();
            //ProcessKeyInput();
            //ProcessFiring();
        }

	}

    //private void ProcessKeyInput()
    //{
    //    //If pause button pressed, load meny and save game mode
    //    if (Input.GetKeyDown(KeyCode.Return)){

    //        //display pause menu canvas
    //    }
    //}

    //void ProcessFiring()
    //{
    //    if (CrossPlatformInputManager.GetButton("Fire")) {

    //        print("Laser beams fired");
    //    }
    //}

    void OnPlayerDeath() //called from string reference
    {
        isControlEnabled = false;
    }

    private void ProcessRotation()
    {
        float pitchByPosition = transform.localPosition.y * positionPitchFactor;

        float pitchByControl = yThrow * controlPitchFactor ;

        float pitch = pitchByPosition + pitchByControl;  //float representing rotation of player in x axis

        float yaw = transform.localPosition.x * positionYawFactor;  //float representing rotation of player in y axis

        float roll = xThrow * controlRollFactor; //float representing rotation of player in z axis

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);


    }

    private void ProcessTranslation()
    {


         xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //float representing how far player has moved horizontally
                                                                        //print(horizontalThrow);
         yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime; //float representing distance moved in the frame
        //print(xOffsetForThisFrame);
        float yOffset = yThrow * speed * Time.deltaTime;
        //print(yOffsetForThisFrame);

        float rawXPos = transform.localPosition.x + xOffset;
        //print(rawXPos);
        float rawYPos = transform.localPosition.y + yOffset;
        //print(rawYPos);

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); // Fixed range player can move horizontally
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange); //Fixed range player can move vertically

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);

    }

    
}
