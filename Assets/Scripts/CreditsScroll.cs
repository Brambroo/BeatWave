using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScroll : MonoBehaviour
{
    public Text creditsText;

    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        //moves the text up at a set speed
        creditsText.gameObject.transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
