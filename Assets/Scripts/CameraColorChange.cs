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
        tool = GameObject.Find("AudioHandler").GetComponent<RhythmTool>();
        colors = new Color[] { Color.white, Color.blue, Color.cyan, Color.green, Color.magenta.gamma, Color.red, Color.yellow, Color.gray };
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (tool.isPlaying)
        {
            interval = tool.BeatTime();
            whenToChange += Time.deltaTime;
            if (whenToChange > interval && interval != 0)
            {
                if (index == colors.Length - 1)
                {
                    camera.backgroundColor = Color.Lerp(colors[index - 1], colors[0], changeSpeed);
                    index = 0;

                }
                camera.backgroundColor = Color.Lerp(colors[index], colors[index + 1], changeSpeed);
                whenToChange = 0;
                index++;
            }
        }

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
