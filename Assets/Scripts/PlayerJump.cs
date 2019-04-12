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
    private int GREENSCORE = 50;
    private int WHITESCORE = 100;
    private int MISSEDSCORE = -100;
    private int GOTHURTSCORE = -50;

    public GameObject particleHandler;

    public bool playerKilledByWhite = false;
    public bool playerKilledByYellow = false;

    void Start()
    {
        //grab the game manager and health manager
        gameManagerScript = gameManager.GetComponent<GameManager>();
        health = this.gameObject.GetComponent<HealthManager>();
    }

    void Update()
    {
        vel = this.gameObject.GetComponent<Rigidbody>().velocity.magnitude;

        //if the player is below the ground, reset their position
        if(this.gameObject.transform.position.y < 0)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 2.5f, this.gameObject.transform.position.z);
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        playerJumping = false;

        //if the player presses space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //check to see if the player was jumping
            if ((this.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 2 || this.gameObject.GetComponent<Rigidbody>().velocity.magnitude < 1) && this.gameObject.transform.position.y > 1.5)
            {
                playerJumping = true;

            }

            //slam back down if they are jumping
            if (playerJumping)
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().AddForce(new Vector2(0, -40), ForceMode.Impulse);
            }

            //jump up depending on the player's position
            if(!(this.gameObject.transform.position.y > 1.5) && !(this.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1))
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().AddForce(new Vector2(0, 10), ForceMode.Impulse);
            }


        }
    }

    /**
     * Handles all collision for the player and behavior depending on what the player collides with
     * 
     * */
    private void OnCollisionEnter(Collision collision)
    {
        //check to see what the player collides with
        if (collision.gameObject.name.Contains("basic"))
        {
            //check to see if the player jumped on the top of the enemy
            Vector3 pos = collision.transform.position;
            if (playerJumping || this.gameObject.transform.position.y >= 1.265)
            {
                gameManagerScript.whiteDefeated();

                //add score to the player's score
               gameManagerScript.addScore(WHITESCORE);
            }
            else
            {

                health.subtractHealth(collision.gameObject, false);

               
     
            }

            //play a hit sound to show th player was hit
            GameObject.Find("Hit sound").GetComponent<AudioSource>().Play();

            //spawn particles
            particleHandler.GetComponent<EnemyKilledParticleEmmitor>().SpawnExplosion(pos, collision.gameObject);

            //destroy the enemy
            Destroy(collision.gameObject);

            //stop the player's movement
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            
        }
        else if (collision.gameObject.name.Contains("Health"))
        {
            //check to see if the player jumped on the top of the enemy
            if (playerJumping || this.gameObject.transform.position.y >= 1.265)
            {
                //add score and health to the player
                gameManagerScript.addScore(GREENSCORE);

                gameManagerScript.greenDefeated();

                health.addHealth();
            }

            //spawn particles
            particleHandler.GetComponent<EnemyKilledParticleEmmitor>().SpawnExplosion(collision.transform.position, collision.gameObject);

            //destroy the enemy
            Destroy(collision.gameObject);

            //stop the player's movement
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else if(collision.gameObject.name.Contains("Sharp"))
        {
            //spawn particles
            particleHandler.GetComponent<EnemyKilledParticleEmmitor>().SpawnExplosion(collision.transform.position, collision.gameObject);

            //subtract health
            health.subtractHealth(collision.gameObject, false);

            

            
            //destroy the enemy
            Destroy(collision.gameObject);

            //stop player movement
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            //subtract from player's score
            gameManagerScript.addScore(GOTHURTSCORE);

        }

        //if the player is colliding with the ground
        if (collision.gameObject.name.Contains("Plane"))
        {
            //stop palyer's movement
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 1.246038f, this.gameObject.transform.position.z);
        }

        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 1.246038f, this.gameObject.transform.position.z);

    }
}
