using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Move", menuName = "SO/Pokemon/Move")]
public class P_Move : ScriptableObject
{
    public string Name;

    public PM_Type Type;
}

public enum PM_Type
{
    physical,
    special,
    status
}
