using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int playerHealth = 3;

    public Sprite yellowPlayer;
    public Sprite redPlayer;
    public Sprite bluePlayer;

    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void subtractHealth()
    {
        playerHealth--;
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

            panel.SetActive(true);

            Destroy(this.gameObject);


        }
    }

    public void addHealth()
    {
        if(playerHealth == 3)
        {
            return;
        }

        playerHealth++;

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
