using System;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

public static class Logger
{
    #region Variables

    static public int Level = 0;
    static public Log_Mode Mode = Log_Mode.Mixed;
    static public File_Mode ModeFile = File_Mode.Single;
    static readonly string Path = "Debug/Logs/Main.log";
    static bool Launched = false;

    #endregion

    #region static Methods

    static public void Note(Type Class, string Message)
    {
        if (Level == 0)
            LogMessage(Class, Message, Log_Type.Note);
    }

    static public void Debug(Type Class, string Message)
    {
        if (Level <= 1)
            LogMessage(Class, Message, Log_Type.Debug);
    }

    static public void Warning(Type Class, string Message)
    {
        if (Level <= 2)
            LogMessage(Class, Message, Log_Type.Warning);
    }

    static public void ErrorWithoutException(Type Class, string Message)
    {
        if (Level <= 3)
            LogMessage(Class, Message, Log_Type.ErrorWithoutException);
    }

    static public void Error(Type Class, string Message)
    {
        if (Level <= 4)
            LogMessage(Class, Message, Log_Type.Error);
    }

    #endregion

    #region Methods

    static void LogMessage(Type Class, string Message, Log_Type Type)
    {
        string FullMessage = "(Class : " + Class.ToString() + ") [" + Type.ToString().ToUpper() + "]: " + Message;

        if (Mode == Log_Mode.File || Mode == Log_Mode.Mixed)
            LogToFile(FullMessage);

        if (Mode == Log_Mode.Console || Mode == Log_Mode.Mixed)
            UnityEngine.Debug.Log(FullMessage);
    }

    static void LogToFile(string Message)
    {
        if (!Launched)
        {
            Launched = true;

            //Debug(MethodBase.GetCurrentMethod().DeclaringType, "Launching Logging System...");

            ClearLogs();

            FileUtils.CreateFile(Path, "|This is the Log File|\n|====================|");

            //Debug(MethodBase.GetCurrentMethod().DeclaringType, "Succefully launched Logging System!");
        }

        File.AppendAllText(FileUtils.GetPath(Path), "\n" + Message);
    }

    static void ClearLogs()
    {
        FileUtils.DeletFile(Path);

        //Debug(MethodBase.GetCurrentMethod().DeclaringType, "Cleared all .log files");
    }

    /* Level System
     * 0 => Note
     * 1 => Debug
     * 2 => Warning
     * 3 => ErrorWithoutException
     * 4 => Error
     */

    #endregion

    #region Enums

    public enum Log_Mode
    {
        Console,
        File,
        Mixed
    }

    public enum Log_Type
    {
        Note,
        Debug,
        Warning,
        ErrorWithoutException,
        Error
    }

    public enum File_Mode
    {
        Single,
        SpreadByClass,
        SpreadByType,
        All
    }

    #endregion
}