using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ImageExtensions
{
    /// <summary>
    /// Changes the Alpha of the Image to the given Float.
    /// </summary>
    public static void ChangeAlpha2(this Image parent, float newAlpha)
    {
        Color newColor = parent.color;
        newColor.a = newAlpha;
        parent.color = newColor;
    }
}
