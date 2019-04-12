using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnEnemy : MonoBehaviour
{
    private HealthManager health;

    private void Start()
    {
        health = GameObject.Find("Player").GetComponent<HealthManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        //if the basic enemy collides with the object the script is attatched to, the player should lose some health
        if (collision.gameObject.name.Contains("basic"))
        {
            health.subtractHealth(collision.gameObject, true);

        }
    }
}
