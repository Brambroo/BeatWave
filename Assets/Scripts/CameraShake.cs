using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject player;

    private float shakeamount = 0;
    private float zPos;
    private float xPos;
    private float yPos;


    private void Start()
    {
        zPos = this.gameObject.transform.position.z;
        xPos = this.gameObject.transform.position.x;
        yPos = this.gameObject.transform.position.y;
    }

    /**
     * Starts the camera shake if the player presses space
     * */
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !(player.transform.position.y > 7.5))
        {
            ShakeCamera(0.1f);
        }
    }

    /**
     * Invokes the Shake function for the length specified
     * */
    private void ShakeCamera(float length)
    {
        shakeamount = 1.5f;

        //will continue to shake until canceled
        InvokeRepeating("Shake", 0f, 0.1f);

        Invoke("StopShake", length);
    }

    /**
     * Moves the camera depeninding on the amount of shake needed
     * */
    private void Shake()
    {
        Vector3 shakePos = Vector3.zero;

        //do the shake
        if(shakeamount > 0)
        {
            float yRandPos = Random.value;

            //set a new position for the y axis 
            shakePos = new Vector3(xPos, yRandPos * shakeamount * 2 - shakeamount, zPos);

            //set the position to the camera
            this.gameObject.transform.position = shakePos;
        }

    }

    /**
     * Stops the camera from moving after Shake has been called
     * */
    private void StopShake()
    {
        //Stops the Shake function
        CancelInvoke("Shake");

        Vector3 playerPos = PlayerMovement.getPlayerPos();

        //resets the player's z axis
        playerPos.z = zPos;

        //sets the camera back to it's original spot
        this.gameObject.transform.position = new Vector3(xPos, yPos, zPos); ;
    }
}
