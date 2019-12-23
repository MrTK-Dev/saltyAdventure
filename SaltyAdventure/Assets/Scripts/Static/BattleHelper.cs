using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class BattleHelper
{
    public static A_TypeEffectiveness GetTypeEffectiveness(P_Type AttackType, PokemonData Pokemon)
    {
        /*P_Type DefendType0 = Pokemon.GeneralInformation.TypePrimus;
        P_Type DefendType1 = Pokemon.GeneralInformation.TypeSecundus;*/

        return GetTypeEffectiveness(AttackType, Pokemon.GeneralInformation.TypePrimus, Pokemon.GeneralInformation.TypeSecundus);
    }

    public static A_TypeEffectiveness GetTypeEffectiveness(P_Type AttackType, P_Type DefendType0, P_Type DefendType1)
    {
        if (AttackType == P_Type.none || DefendType0 == P_Type.none)
            Logger.Warning(MethodBase.GetCurrentMethod().DeclaringType, "Either your Attack Move or your Defender has no Type - you should check this out!");

        A_TypeEffectiveness Type_0 = GetSingleTypeEffectiveness(AttackType, DefendType0);

        if (DefendType1 != P_Type.none)
        {
            A_TypeEffectiveness Type_1 = GetSingleTypeEffectiveness(AttackType, DefendType1);

            if (Type_0 == A_TypeEffectiveness.InEffective || Type_1 == A_TypeEffectiveness.InEffective)
                return A_TypeEffectiveness.InEffective;

            else if (Type_0 == A_TypeEffectiveness.Effective && Type_1 == A_TypeEffectiveness.Effective)
                return A_TypeEffectiveness.VeryEffective;

            else if (Type_0 == A_TypeEffectiveness.NotEffective && Type_1 == A_TypeEffectiveness.NotEffective)
                return A_TypeEffectiveness.NotVeryEffective;

            else if (
                    (Type_0 == A_TypeEffectiveness.Effective && Type_1 == A_TypeEffectiveness.NotEffective)
                    ||
                    (Type_0 == A_TypeEffectiveness.NotEffective && Type_1 == A_TypeEffectiveness.Effective)
                    ||
                    (Type_0 == A_TypeEffectiveness.Neutral && Type_1 == A_TypeEffectiveness.Neutral)
                    )
                return A_TypeEffectiveness.Neutral;

            else if (
                    (Type_0 == A_TypeEffectiveness.Effective && Type_1 == A_TypeEffectiveness.Neutral)
                    ||
                    (Type_0 == A_TypeEffectiveness.Neutral && Type_1 == A_TypeEffectiveness.Effective)
                    )
                return A_TypeEffectiveness.Effective;

            else if (
                    (Type_0 == A_TypeEffectiveness.NotEffective && Type_1 == A_TypeEffectiveness.Neutral)
                    ||
                    (Type_0 == A_TypeEffectiveness.Neutral && Type_1 == A_TypeEffectiveness.NotEffective)
                    )
                return A_TypeEffectiveness.NotEffective;

            else
            {
                Logger.Error(MethodBase.GetCurrentMethod().DeclaringType, "There is something wrong in the Effectivness Checker!");

                return A_TypeEffectiveness.Neutral;
            }
        }

        else
            return Type_0;
    }

    static A_TypeEffectiveness GetSingleTypeEffectiveness(P_Type AttackType, P_Type DefendType)
    {
        TypeData AttackData = TypeData.GetData(AttackType);
        //TypeData DefenseData = TypeData.GetData(DefenseType);

        if (AttackData.EffectiveTo.Contains(DefendType))
            return A_TypeEffectiveness.Effective;

        else if (AttackData.ResistedBy.Contains(DefendType))
            return A_TypeEffectiveness.NotEffective;

        else if (AttackData.IneffectiveTo.Contains(DefendType))
            return A_TypeEffectiveness.InEffective;

        else
            return A_TypeEffectiveness.Neutral;
    }
}

public enum A_TypeEffectiveness
{
    VeryEffective,
    Effective,
    Neutral,
    NotEffective,
    NotVeryEffective,
    InEffective
}