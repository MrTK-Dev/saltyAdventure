using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtensions
{
    public static bool EndsWithMulti(this string String, string[] Checks)
    {
        bool EndsWith = new bool();

        for (int i = 0; i < Checks.Length; i++)
        {
            if (String.EndsWith(Checks[i]))
            {
                EndsWith = true;

                break;
            }
        }

        return EndsWith;
    }
}
