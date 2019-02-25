using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour
{
    public GameObject[] infoElements = new GameObject[3];
    public GameObject[] mainElements = new GameObject[3];

    
    public void Hide()
    {

        for (int i = 0; i < infoElements.Length; i++)
        {
            infoElements[i].active = true;
        }

        for(int i = 0; i < mainElements.Length; i++)
        {
            mainElements[i].active = false;
        }
    }

    public void Show()
    {
        for (int i = 0; i < infoElements.Length; i++)
        {
            infoElements[i].active = false;
        }

        for (int i = 0; i < mainElements.Length; i++)
        {
            mainElements[i].active = true;
        }
    }
}
