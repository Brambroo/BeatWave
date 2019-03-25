using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 5f;
    public RhythmTool tool;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector2(-5, 0), ForceMode.Impulse);
        tool = GameObject.Find("AudioHandler").GetComponent<RhythmTool>();

        speed = tool.bpm / 30;
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = tool.bpm / 30;
        this.gameObject.transform.position += Time.deltaTime * Vector3.left * speed;
    }
}
