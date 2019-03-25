using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public static bool hasBeenRestarted = false;
    public static string oldPath;

    public void Redo()
    {
        hasBeenRestarted = true;
        oldPath = StartGame.path;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
