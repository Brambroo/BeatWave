using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCredits : MonoBehaviour
{
    private float creditsTime = 0;

    void Update()
    {
        creditsTime += Time.deltaTime;

        if(creditsTime > 70f)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        //if the player its the enter key, they are returned to the main menu
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}
