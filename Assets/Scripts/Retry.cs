using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public static bool hasBeenRestarted = false;
    public static string oldPath;

    /**
     * Used to restart the song and game
     * */
    public void Redo()
    {
        hasBeenRestarted = true;
        oldPath = StartGame.path;

        //reloads the scene
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
