using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtensions
{
    /// <summary>
    /// Checks if the given String ends with one of the Strings in the given Array.
    /// </summary>
    public static bool EndsWithMulti(this string String, string[] StringsToCheck)
    {
        bool EndsWith = new bool();

        for (int i = 0; i < StringsToCheck.Length; i++)
        {
            if (String.EndsWith(StringsToCheck[i]))
            {
                EndsWith = true;

                break;
            }
        }

        return EndsWith;
    }

    public static string ToLower(this string String, bool ChangeSpace)
    {
        string newString;

        newString = String.ToLower().Replace(" ", "_");

        return newString;
    }
}
