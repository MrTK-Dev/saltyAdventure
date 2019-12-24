using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class TrainerInfo
{
    public static TrainerData ActiveTrainer = TrainerData.GetData();

    public static void SetActiveTrainer(TrainerData Trainer)
    {
        if (ActiveTrainer != Trainer)
            ActiveTrainer = Trainer;
    }

    #region Money

    public static void AddMoney(int newMoney)
    {
        ActiveTrainer.Money += newMoney;
    }

    public static void RemoveMoney(int newMoney)
    {
        if (ActiveTrainer.Money - newMoney < 0)
            Logger.Error(MethodBase.GetCurrentMethod().DeclaringType, "You are trying to get the money lower than 0!");

        else
            ActiveTrainer.Money -= newMoney;
    }

    #endregion
}
