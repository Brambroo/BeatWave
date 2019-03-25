using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnEnemy : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("basic"))
        {
            Destroy(collision.gameObject);
            GameObject.Find("Player").GetComponent<HealthManager>().subtractHealth();
        }
    }
}
