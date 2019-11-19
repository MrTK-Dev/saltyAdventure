using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public string Formatting3Int(string Text2Format)
    {
        return string.Format("{0:###,###,###}", Text2Format);
    }
}
