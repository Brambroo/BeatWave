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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !(player.transform.position.y > 7.5))
        {
            ShakeCamera(0.1f);
        }
    }

    private void ShakeCamera(float length)
    {
        shakeamount = 1.0f;
        InvokeRepeating("Shake", 0f, 0.1f);
        Invoke("StopShake", length);
    }

    private void Shake()
    {
        Vector3 shakePos = Vector3.zero;

        if(shakeamount > 0)
        {
            float yRandPos = Random.value;

            shakePos = new Vector3(xPos, yRandPos * shakeamount * 2 - shakeamount, zPos);

            this.gameObject.transform.position = shakePos;
        }

    }

    private void StopShake()
    {
        CancelInvoke("Shake");

        Vector3 playerPos = PlayerMovement.getPlayerPos();
        playerPos.z = zPos;

        this.gameObject.transform.position = new Vector3(xPos, yPos, zPos); ;
    }
}
