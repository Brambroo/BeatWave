﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChange : MonoBehaviour
{

    public float changeSpeed;
    public float interval = 0.1f;

    private Renderer backgroundRenderer;
    private Color[] colors;
    private float whenToChange = 0.1f;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        //grab the camera's renderer
        backgroundRenderer = this.gameObject.GetComponent<Renderer>();

        //initalize all of the possible colors
        colors = new Color[] { Color.blue, Color.cyan, Color.green, Color.magenta.gamma, Color.red, Color.yellow, Color.gray, Color.white };
    }

    // Update is called once per frame
    void Update()
    {
        //add realtime to when to change
        whenToChange += Time.deltaTime;

        //if it's time to change colors
        if(whenToChange > interval)
        {
            if(index == colors.Length-1)
            {
                backgroundRenderer.material.color = Color.Lerp(colors[index - 1], colors[0], changeSpeed);
                index = 0;

            }
            backgroundRenderer.material.color = Color.Lerp(colors[index], colors[index + 1], changeSpeed);
            whenToChange = 0;
            index++;
        }
        
    }
}
