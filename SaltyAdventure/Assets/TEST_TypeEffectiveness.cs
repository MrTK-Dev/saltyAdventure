using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_TypeEffectiveness : MonoBehaviour
{
    public P_Type AttackType = P_Type.none;
    public P_Type DefendType0 = P_Type.none;
    public P_Type DefendType1 = P_Type.none;

    public void OnClick()
    {
        A_TypeEffectiveness typeEffectiveness =  BattleHelper.GetTypeEffectiveness(AttackType, DefendType0, DefendType1);

        if (DefendType1 != P_Type.none)
            Logger.Debug(GetType(), "'" + AttackType.ToString() + "' is '" + typeEffectiveness.ToString() + "' on '" + 
                DefendType0.ToString() + "' & '" + DefendType1.ToString() + "'.");
        else
            Logger.Debug(GetType(), "'" + AttackType.ToString() + "' is '" + typeEffectiveness.ToString() + "' on '" +
                DefendType0.ToString() + "'.");
    }
}
