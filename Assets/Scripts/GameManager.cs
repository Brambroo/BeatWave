using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int whiteEnemy = 0;
    public int greenEnemy = 0;
    public int yellowEnemy = 0;
    public int hitsTaken = 0;

    public Text greenText;
    public Text hitText;
    public Text yellowText;
    public Text whiteText;
    public Text scoreText;

    public Text retryText;
    public Text winText;

    public RhythmTool tool;

    public GameObject panel;
    public GameObject particleHandler;

    private void Start()
    {
        //grab the audio analysis tool
        tool = GameObject.Find("AudioHandler").GetComponent<RhythmTool>();
        new WaitForSecondsRealtime(3);

        //start endGame coroutine
        StartCoroutine(endGame());
    }

    /**
     * Adds to the score of the play session
     * */
    public void addScore(int score)
    {
        this.score += score;
    }

    /**
     * Adds to the number of white enemies defeated
     * */
    public void whiteDefeated()
    {
        whiteEnemy++;
    }

    /**
     * Adds to the number of yellow enemies defeated
     * */
    public void yellowDefeated()
    {
        yellowEnemy++;
    }

    /**
     * Adds to the number of green enemies defeated
     * */
    public void greenDefeated()
    {
        greenEnemy++;
    }

    /**
     * Adds to hitsTaken, called when the player takes a hit
     * */
    public void takenAHit()
    {
        hitsTaken++;
    }

    /**
     * Populates the UI screen with score information
     * */
    public void populateScore()
    {
        greenText.text = greenEnemy + "";
        yellowText.text = yellowEnemy + "";
        whiteText.text = whiteEnemy + "";
        scoreText.text = score + "";
        hitText.text = hitsTaken + "";
    }

    /**
     * Ends the game
     * 
     * */
    IEnumerator endGame()
    {
        //if the player has completed the song
        yield return new WaitUntil(() => !tool.isPlaying && (whiteEnemy > 0 || greenEnemy > 0 || yellowEnemy > 0) && GameObject.Find("Player").GetComponent<HealthManager>().playerHealth > 0);

        //populate the score
        populateScore();
        
        //make the win screen UI visible
        panel.SetActive(true);
        retryText.enabled = false;
        winText.enabled = true;

        //grab all of the left over enemies
        GameObject[] leftOverEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        //play the win sound
        GameObject.Find("Win Sound").GetComponent<AudioSource>().Play();

        //iterate through the left over enemies and destroy them all
        for (int i = 0; i < leftOverEnemies.Length; i++)
        {
            Destroy(leftOverEnemies[i]);
        }

    }

}
