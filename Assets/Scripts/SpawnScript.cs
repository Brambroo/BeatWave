using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnScript : MonoBehaviour
{
    public float delay = 0.1f;
    public float time = 0.1f;
    public float interval = 0;
    public float whenToSpawn = 0;
    public RhythmTool tool;

    public GameObject enemyPrefab;
    public Vector3 whereToSpawn;
    private float nextSpawn = 0;

    public GameObject[] enemies;

    public HealthManager health;

    private System.Random rand;
    private bool hasSpawned = false;


    private int num;

    // Start is called before the first frame update
    void Start()
    {
        tool = GameObject.Find("AudioHandler").GetComponent<RhythmTool>();
        rand = new System.Random();
        health = GameObject.Find("Player").GetComponent<HealthManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tool.isPlaying)
        {
            interval = tool.BeatTime();
            whenToSpawn += Time.deltaTime;

            if (whenToSpawn > interval && interval != 0)
            {
                if (hasSpawned)
                {
                    hasSpawned = false;
                    whenToSpawn = 0;
                }
                else
                {
                    Vector3 newPos = new Vector3(transform.position.x, transform.position.y, 0f);
                    int tempNum = rand.Next(0, 3);
                    if(num == 2 && tempNum == 2)
                    {
                        tempNum = 0;
                        num = 0;
                    }

                    if(tempNum == 1 && health.playerHealth == 3)
                    {
                        tempNum = 0;
                    }
                    Instantiate(enemies[tempNum], newPos, Quaternion.identity);
                    num = tempNum;
                    hasSpawned = true;
                    whenToSpawn = 0;
                }
            }
        }
    }
}
