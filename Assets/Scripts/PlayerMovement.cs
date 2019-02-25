using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static Vector3 playerPosition;
    private float bpmOffset;


    // Start is called before the first frame update
    void Start()
    {
        bpmOffset = 0; //Get from audio analysis
        playerPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += Time.deltaTime * Vector3.right * bpmOffset; //might need to change in the future for physics reasons
        playerPosition = this.gameObject.transform.position;
    }

    public static Vector3 getPlayerPos()
    {
        return playerPosition;
    }
}
