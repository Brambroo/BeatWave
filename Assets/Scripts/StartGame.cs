using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Crosstales.FB;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public static string path;

    public void StartFileBrowser()
    {
        path = FileBrowser.OpenSingleFile("wav");
        Debug.Log("Selected file: " + path);

        if(path != "")
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}
