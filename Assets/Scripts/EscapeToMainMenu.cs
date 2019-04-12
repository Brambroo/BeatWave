using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeToMainMenu : MonoBehaviour
{
    void Update()
    {
        //if the player presses the escape button, then the player is taken back to the main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}
