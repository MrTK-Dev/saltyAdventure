using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_SwitchButton : MonoBehaviour
{
    public Sprite Resume;
    public Sprite Pause;

    public void SetResume()
    {
        GetComponentInChildren<SVGImage>().sprite = Pause;
    }

    public void SetPause()
    {
        GetComponentInChildren<SVGImage>().sprite = Resume;
    }
}
