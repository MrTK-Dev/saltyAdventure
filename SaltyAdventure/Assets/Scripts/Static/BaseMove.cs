using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMove
{
    public Move Move = Move.none;
    public int CurrentPP = 0;
    public int MaxPP = 0;

    public bool isDisabled = false;
}
