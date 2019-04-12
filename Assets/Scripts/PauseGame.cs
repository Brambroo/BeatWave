using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject losePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        Debug.Log(Time.timeScale);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy && !winPanel.activeInHierarchy && !losePanel.activeInHierarchy)
            {
                Pause();
            }
            else if (pausePanel.activeInHierarchy || Time.timeScale == 1)
            {
                ContinueGame();
            }
        }
    }
    private void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        GameObject.Find("Player").GetComponent<PlayerJump>().enabled = false;
        GameObject.Find("Main Camera").GetComponent<CameraShake>().enabled = false;
        GameObject.Find("Spawner").GetComponent<SpawnScript>().enabled = false;
        GameObject.Find("AudioHandler").GetComponent<RhythmTool>().Pause();
        GameObject.Find("Audio Handler").GetComponent<AudioSource>().Pause();
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerJump>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<CameraShake>().enabled = true;
        GameObject.Find("Spawner").GetComponent<SpawnScript>().enabled = true;
        GameObject.Find("AudioHandler").GetComponent<RhythmTool>().Play();
        GameObject.Find("Audio Handler").GetComponent<AudioSource>().Play();



        //enable the scripts again
    }
}
