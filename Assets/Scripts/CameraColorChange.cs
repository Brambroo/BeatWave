using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorChange : MonoBehaviour
{

    public float changeSpeed;
    public float interval = 0.1f;
    public Camera camera;
    public RhythmTool tool;

    private Color[] colors;
    private float whenToChange = 0.1f;
    private int index = 0;
    private int wait = 0;

    // Start is called before the first frame update
    void Start()
    {
        //grab the audio analysis tool
        tool = GameObject.Find("AudioHandler").GetComponent<RhythmTool>();

        //initalize the colors that can be changed
        colors = new Color[] { Color.white, Color.blue, Color.cyan, Color.green, Color.magenta.gamma, Color.red, Color.yellow, Color.gray };

        //wait for 2 seconds
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        //if audio alaysis is being done
        if (tool.isPlaying)
        {
            //grab the interval between beats
            interval = tool.BeatTime();

            //add realtime to whenToChange
            whenToChange += Time.deltaTime;

            //if it's time to change the color
            if (whenToChange > interval && interval != 0)
            {
                //change colors 
                if (index == colors.Length - 1)
                {
                    camera.backgroundColor = Color.Lerp(colors[index - 1], colors[0], changeSpeed);
                    index = 0;

                }

                //reset values
                camera.backgroundColor = Color.Lerp(colors[index], colors[index + 1], changeSpeed);
                whenToChange = 0;
                index++;
            }
        }

    }

    /**
     * Waits for 2 seconds
     * */
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
