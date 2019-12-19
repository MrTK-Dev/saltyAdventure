using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExtensions
{
    /// <summary>
    /// 
    /// </summary>
    public static string TimeFormat(this float Integer, string Format)
    {
        string newString = "";

        if (Format == "dhm")
        {
            newString = string.Format("{0:0}d {1:00}h {2:00}m", (Integer / 86400) % 24, (Integer / 3600) % 60, (Integer / 60) % 60);
        }

        return newString;
    }
}