﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using UnityEngine;

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
        source = this.gameObject.GetComponent<AudioSource>();
        tool = this.gameObject.GetComponent<RhythmTool>();



        if (Retry.hasBeenRestarted)
        {
            path = Retry.oldPath;
            Retry.hasBeenRestarted = false;
        }
        else
        {
            path = StartGame.path;
        }

        fileExt = Path.GetFileName(path);

        file = "file://" + path;
        //WWW tr = new WWW(file);

        //uploadedFile = tr.GetAudioClip();

        StartCoroutine(LoadAudio());

        //source.clip = uploadedFile;


    }

    private IEnumerator LoadAudio()
    {
        WWW request = new WWW(path);
        yield return request;

        uploadedFile = request.GetAudioClip();
        uploadedFile.name = fileExt;

        PlayAudioFile();
    }

    private void PlayAudioFile()
    {
        source.clip = uploadedFile;
        tool.audioClip = source.clip;
        source.Play();
    }

   

    private void Update()
    {
        //for (int i = 0; i < waveForm.Length - 1; i++)
        //{
        //    Vector3 sv = new Vector3(i * .01f, waveForm[i] * 10, 0);
        //    Vector3 ev = new Vector3(i * .01f, -waveForm[i] * 10, 0);

        //    Debug.DrawLine(sv, ev, Color.yellow);
        //}

        //int current = source.timeSamples / resolution;
        //current *= 2;

        //Vector3 c = new Vector3(current * .01f, 0, 0);

        //Debug.DrawLine(c, c + Vector3.up * 10, Color.white);
    }

    //public void drawWaveform()
    //{
    //    samples = new float[source.clip.samples * source.clip.channels];
    //    source.clip.GetData(samples, 0);



    //    for (int i = 0; i < samples.Length; i++)
    //    {
    //        Debug.DrawLine(new Vector3(samples[i]));
    //    }
    //}

}