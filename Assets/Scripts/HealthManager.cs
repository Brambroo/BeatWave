using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PE2D;


public class HealthManager : MonoBehaviour
{
    public int playerHealth = 3;

    public Sprite yellowPlayer;
    public Sprite redPlayer;
    public Sprite bluePlayer;

    public GameObject panel;

    private GameManager manager;
    private PlayerJump jumpScript;

    private void Start()
    {
        jumpScript = GameObject.Find("Player").GetComponent<PlayerJump>();
        manager = GameObject.Find("GameHandler").GetComponent<GameManager>();
    }

    /**
     * Subtracts a value from the player's health
     * */
    public void subtractHealth(GameObject enemy, bool despawned)
    {
        if (enemy.name.Contains("basic") && !despawned)
        {
            manager.whiteDefeated();
        }
        else if (enemy.name.Contains("Sharp") && !despawned)
        {
            manager.yellowDefeated();
        }
        

        manager.takenAHit();
        playerHealth--;

        //change the sprite of the player depending on how much health they have left
        if(playerHealth == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = yellowPlayer;
        }
        else if(playerHealth == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = redPlayer;
        }
        else
        {
            if (jumpScript.playerKilledByWhite)
            {
                manager.whiteDefeated();
            }
            else if (jumpScript.playerKilledByYellow)
            {
                manager.yellowDefeated();
            }

            //the player has lost all of their health and the game ends
            panel.SetActive(true);

            //play fail noise
            GameObject.Find("Record Scratch").GetComponent<AudioSource>().Play();

            //stop all audio
            GameObject.Find("AudioHandler").GetComponent<RhythmTool>().Stop();
            GameObject.Find("AudioHandler").GetComponent<AudioSource>().Stop();

            //disable the particle effector
            this.gameObject.GetComponent<ParticleEffector>().enabled = false;
            Destroy(GameObject.Find("ParticleHandler"));

            //destroy the player
            Destroy(this.gameObject);

            //populate the game score
            GameObject.Find("GameHandler").GetComponent<GameManager>().populateScore();
        }
    }

    /**
     * Adds hit points to the player
     * */
    public void addHealth()
    {
        manager.greenDefeated();

        //if the player has full health, do nothing
        if(playerHealth == 3)
        {
            return;
        }

        //add health
        playerHealth++;

        //change the sprite of the player depending on how many hit points they have
        if(playerHealth == 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bluePlayer;
        }
        else if(playerHealth == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = yellowPlayer;
        }

    }
}
