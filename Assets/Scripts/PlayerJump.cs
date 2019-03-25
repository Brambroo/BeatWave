using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public float vel;
    public bool playerJumping = false;

    public GameObject gameManager;
    public GameManager gameManagerScript;

    public HealthManager health;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(StartGame.path);
        gameManagerScript = gameManager.GetComponent<GameManager>();
        health = this.gameObject.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        vel = this.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        //TODO Stop player from jumping mid-air
        if(this.gameObject.transform.position.y < 0)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 2.5f, this.gameObject.transform.position.z);
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        playerJumping = false;

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if ((this.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 2 || this.gameObject.GetComponent<Rigidbody>().velocity.magnitude < 1) && this.gameObject.transform.position.y > 1.5)
            {
                playerJumping = true;
            }

            if (playerJumping)
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().AddForce(new Vector2(0, -40), ForceMode.Impulse);

            }

   
            if(!(this.gameObject.transform.position.y > 1.5) && !(this.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1))
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

                this.GetComponent<Rigidbody>().AddForce(new Vector2(0, 10), ForceMode.Impulse);

                

            }


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("basic"))
        {
            if (playerJumping || this.gameObject.transform.position.y >= 1.265)
            {
               gameManagerScript.addScore(500);
            }
            else
            {
                health.subtractHealth();
            }
            Destroy(collision.gameObject);
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else if (collision.gameObject.name.Contains("Health"))
        {
            health.addHealth();
            Destroy(collision.gameObject);
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else if(collision.gameObject.name.Contains("Sharp"))
        {
            health.subtractHealth();
            Destroy(collision.gameObject);
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (collision.gameObject.name.Contains("Plane"))
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 1.246038f, this.gameObject.transform.position.z);
        }

        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 1.246038f, this.gameObject.transform.position.z);

    }



}
