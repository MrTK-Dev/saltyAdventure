using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController
{
    public static bool GamePaused;

    // Update is called once per frame
    public static void FreezeTime()
    {
        Time.timeScale = 0;
        Debug.Log("time froze");
        GamePaused = true;
    }
    public static void ResumeTime()
    {
        Time.timeScale = 1;
        Debug.Log("time continues");
        GamePaused = false;
    }
}
