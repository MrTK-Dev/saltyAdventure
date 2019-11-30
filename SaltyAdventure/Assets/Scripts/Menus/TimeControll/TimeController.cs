using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static bool GamePaused;

    // Update is called once per frame
    public void FreezeTime()
    {
        Time.timeScale = 0;
        Debug.Log("time froze");
        GamePaused = true;
    }
    public void ResumeTime()
    {
        Time.timeScale = 1;
        Debug.Log("time continues");
        GamePaused = false;
    }
}
