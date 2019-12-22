using System.IO;
using System.Reflection;
using UnityEngine;

/// <summary>
/// Handles Writing & Reading of JSON.
/// </summary>
public static class DataManagment
{
    #region Write to JSON

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

    #endregion

    #region Read from JSON

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

    #endregion
}

/// <summary>
/// Handles Writing & Reading of Files
/// </summary>
public static class FileUtils
{
    #region Create File

    public static void CreateFile(string Path)
    {
        CreateFile(Path, "");
    }

    public static void CreateFile(string Path, string Text)
    {
        string FileName = Path.Split("/"[0])[Path.Split("/"[0]).Length - 1];

        if (!File.Exists(GetPath(Path)))
        {
            File.WriteAllText(GetPath(Path), Text);

            Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "Created '" + FileName + "' at '" + Path.Replace(FileName, "") + "'");
        }

        else
            Logger.Warning(MethodBase.GetCurrentMethod().DeclaringType, "'" + FileName + "' at '" + Path.Replace(FileName, "") + "' already Exists!");
    }

    #endregion

    #region Append Files

    public static void AppendFile(string Path, string Text, string StartMesssage)
    {
        if (!File.Exists(GetPath(Path)))
        {
            CreateFile(Path, StartMesssage);
        }

        File.AppendAllText(GetPath(Path), "\n" + Text);
    }

    public static void AppendFile(string Path, string Text)
    {
        AppendFile(Path, Text, "");
    }

    #endregion

    #region Delete File

    public static void DeletFile(string Path)
    {
        if (File.Exists(GetPath(Path)))
        {
            File.Delete(GetPath(Path));

            //Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "Deleted '" + Path + "'");
        }
    }

    #endregion

    #region Help Methods

    public static string GetPath(string Path)
    {
        return Application.dataPath + "/" + Path;
    }

    #endregion
}