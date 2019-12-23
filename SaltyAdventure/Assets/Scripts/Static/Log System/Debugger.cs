using System;
using System.IO;

public static class Logger
{
    #region Variables

    static public int Level = 0;
    static public Log_Mode Mode = Log_Mode.Console;
    static public File_Mode ModeFile = File_Mode.Single;
    static readonly string BasePath = "Debug/Logs/";
    static bool Launched = false;

    #endregion

    #region static Methods

    static public void Info(Type Class, string Message)
    {
        if (Level == 0)
            LogMessage(Class, Message, Log_Type.INFO);
    }

    static public void Debug(Type Class, string Message)
    {
        if (Level <= 1)
            LogMessage(Class, Message, Log_Type.DEBUG);
    }

    static public void Warning(Type Class, string Message)
    {
        if (Level <= 2)
            LogMessage(Class, Message, Log_Type.WARNING);
    }

    static public void Error(Type Class, string Message)
    {
        if (Level <= 3)
            LogMessage(Class, Message, Log_Type.ERROR);
    }

    static public void Exception(Type Class, string Message)
    {
        if (Level <= 4)
            LogMessage(Class, Message, Log_Type.EXCEPTION);

        throw new Exception(Message);
    }

    #endregion

    #region Methods

    static void LogMessage(Type Class, string Message, Log_Type Type)
    {
        string FullMessage = "(CLASS : " + Class.ToString() + ") [" + Type.ToString().ToUpper() + "]: " + Message;

        if (Mode == Log_Mode.File || Mode == Log_Mode.Mixed)
            //LogToFile(FullMessage);
            TOFILE(Class, Type, FullMessage);

        if (Mode == Log_Mode.Console || Mode == Log_Mode.Mixed)
            UnityEngine.Debug.Log(FullMessage);
    }

    static void TOFILE(Type Class, Log_Type Type, string Message)
    {
        if (!Launched)
        {
            Launched = true;

            ClearLogs();
        }

        string[] Paths = new string[3];

        Paths[0] = "Main";

        switch (ModeFile)
        {
            case File_Mode.Single:
                break;

            case File_Mode.SpreadByClass:
                Paths[1] = "/SpreadByClass/" + Class;
                break;

            case File_Mode.SpreadByType:
                Paths[2] = "/SpreadByType/" + Type.ToString().ToLower();
                break;

            case File_Mode.All:
                Paths[1] = "/SpreadByClass/" + Class;
                Paths[2] = "/SpreadByType/" + Type.ToString().ToLower();
                break;

            default:
                break;
        }

        for (int i = 0; i < Paths.Length; i++)
        {
            if (Paths[i] != null)
                FileUtils.AppendFile(BasePath + Paths[i] + ".log", Message, "|" + Paths[i] + ".log" + "|\n|====================|");
        }
    }


    static void ClearLogs()
    {
        string Path_All = FileUtils.GetPath(BasePath);

        if (Directory.Exists(Path_All))
            Directory.Delete(Path_All, true);

        Directory.CreateDirectory(Path_All);
        Directory.CreateDirectory(Path_All + "/SpreadByClass");
        Directory.CreateDirectory(Path_All + "/SpreadByType");
    }

    /* Level System
     * 0 => Info
     * 1 => Debug
     * 2 => Warning
     * 3 => Error
     * 4 => Exception
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
        INFO,
        DEBUG,
        WARNING,
        ERROR,
        EXCEPTION
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