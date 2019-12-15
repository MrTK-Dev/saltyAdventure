using System.IO;
using UnityEngine;

/// <summary>
/// Handles Writing & Reading of JSON.
/// </summary>
public static class DataManagment
{
    /// <summary>
    /// Writes the given Class to the given Path.
    /// </summary>
    /// <param name="Object">Class to save</param>
    /// <param name="Path">Path of the File</param>
    public static void WriteToJSON(object Object, string Path)
    {
        string DatabaseToJson = JsonUtility.ToJson(Object, true);

        File.WriteAllText(Application.dataPath + "/SaveFiles/" + Path + ".json", DatabaseToJson);
    }

    /// <summary>
    /// Returns the Text in the given Path as a String.
    /// </summary>
    /// <param name="Path">Path of the given File</param>
    /// <returns>JSON as string</returns>
    public static string ReadFromJSON(string Path)
    {
        string JSON = File.ReadAllText(Application.dataPath + "/SaveFiles/" + Path + ".json");

        return JSON;
    }
}
