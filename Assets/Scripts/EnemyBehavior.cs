using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 5f;
    public RhythmTool tool;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        //push the enemy out to the left to start it's movement
        this.GetComponent<Rigidbody>().AddForce(new Vector2(-5, 0), ForceMode.Impulse);

        //grab the audio analysis tool
        tool = GameObject.Find("AudioHandler").GetComponent<RhythmTool>();

        //grab the game mangaer
        manager = GameObject.Find("GameHandler").GetComponent<GameManager>();

        //set the movement speed to the bpm
        speed = tool.bpm;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the audio analysis is running
        if (tool.isPlaying)
        {
            speed = tool.bpm /30;
            this.gameObject.transform.position += Time.deltaTime * Vector3.left * speed;

            
        }
        else if(!tool.isPlaying && (manager.whiteEnemy > 0 || manager.greenEnemy > 0 || manager.yellowEnemy > 0))
        {
            //Do nothing
        }
    }
}
