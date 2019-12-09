using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class TextExtensions
{
    /// <summary>
    /// Adds the TypeWriterEffect with the given String.
    /// Has to be used with StartCoroutine():
    /// <code>
    /// StartCoroutine(TextField.TypeWriterEffect(Text));
    /// </code>
    /// @Optional set Delay [default = 0.02s]
    /// @Optional set PuncDelay [default = 0.1s]
    /// </summary>
    public static IEnumerator TypeWriterEffect(this Text TextField, string Text, float Delay = 0.02f, float PuncDelay = 0.1f)
    {
        for (int i = 0; i < (Text.Length + 1); i++)
        {
            TextField.text = Text.Substring(0, i);

            if (Text.Substring(0, i).EndsWith("."))  //Delay
            {
                yield return new WaitForSeconds(PuncDelay);
            }
            if (Text.Substring(0, i).EndsWithMulti(new string[] { ",", ":", ";" }))
            {
                yield return new WaitForSeconds(PuncDelay / 2);
            }
            else
            {
                yield return new WaitForSeconds(Delay);
            }
        }
    }

    /// <summary>
    /// Adds the TypeWriterEffect with the given String.
    /// Has to be used with StartCoroutine():
    /// <code>
    /// StartCoroutine(TextField.TypeWriterEffect(Text));
    /// </code>
    /// @Optional set Delay [default = 0.02s]
    /// @Optional set PuncDelay [default = 0.1s]
    /// </summary>
    public static IEnumerator TypeWriterEffect(this TextMeshProUGUI TextField, string Text, float Delay = 0.02f, float PuncDelay = 0.1f)
    {
        for (int i = 0; i < (Text.Length + 1); i++)
        {
            TextField.text = Text.Substring(0, i);

            if (Text.Substring(0, i).EndsWith("."))  //Delay
            {
                yield return new WaitForSeconds(PuncDelay);
            }
            if (Text.Substring(0, i).EndsWithMulti(new string[] { ",", ":", ";" }))
            {
                yield return new WaitForSeconds(PuncDelay / 2);
            }
            else
            {
                yield return new WaitForSeconds(Delay);
            }
        }
    }
}
