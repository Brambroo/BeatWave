using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using UnityEngine;

/**
 * 
 * Handles all of the initalization of the audio file that the player chooses and initalizes the Audio Analyzer
 * 
 * */
public class AudioAnalysis : MonoBehaviour
{
    public AudioSource source;
    public AudioClip uploadedFile;
    public RhythmTool tool;
    public float[] samples;

    public GameObject background;

    public LineRenderer line;

    private string path;
    private string file;
    string fileExt;

    int resolution = 60;

    float[] waveForm;

    void Start()
    {
        //grab the audio source and the audio analysis tool
        source = this.gameObject.GetComponent<AudioSource>();
        tool = this.gameObject.GetComponent<RhythmTool>();

        //check to see if the game has been restarted or not
        if (Retry.hasBeenRestarted)
        {
            //if so, reset the path to file
            path = Retry.oldPath;
            Retry.hasBeenRestarted = false;
        }
        else
        {
            path = StartGame.path;
        }

        //get the file extention
        fileExt = Path.GetFileName(path);

        //create the file path
        file = "file://" + path;

        StartCoroutine(LoadAudio());
    }

    /**
     * Loads the audio file that was chosen by the user
     * */
    private IEnumerator LoadAudio()
    {
        //set the file and grab it from the computer's directory
        WWW request = new WWW(path);
        yield return request;

        uploadedFile = request.GetAudioClip();
        uploadedFile.name = fileExt;

        PlayAudioFile();
    }

    /**
     * Plays the Audio file grabbed
     * */
    private void PlayAudioFile()
    {
        source.clip = uploadedFile;
        tool.audioClip = source.clip;
        source.Play();
    }


}
