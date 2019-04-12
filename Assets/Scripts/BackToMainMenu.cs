using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public void GoBack()
    {
        //loads the main menu scene
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
