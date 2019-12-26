using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class Encounter_Manager
{
    static public void Encounter(Place newPlace)
    {
        PlaceData PlaceData = PlaceData.GetData(newPlace);

        Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "Starting 'Encounter' ...");
        Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "Place: " + PlaceData.Name);

        PokemonData PokemonData = PokemonData.GetData(GetByRarity(PlaceData));

        Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "Monster: " + PokemonData.GeneralInformation.Name);

        BasePokemon Pokemon = GetPokemon(PokemonData, PlaceData);

        Pokemon_Party.AddPokemonToParty(Pokemon);
    }

    static BasePokemon GetPokemon(PokemonData PokemonData, PlaceData Place)
    {
        BasePokemon Pokemon = new BasePokemon
        {
            Monster = PokemonData.GeneralInformation.Monster,
            Name = PokemonData.GeneralInformation.Name,
            Nature = Natures.GetRandomNature(),
            Level = GetLevel(Place, PokemonData),
            Ability = GetRandomAbility(PokemonData),
            isShiny = CheckForShiny(),
            Happiness = PokemonData.Breeding.BaseHappiness,
            Gender = GetRandomGender(PokemonData),

            TrainerInfo = new P_Trainer()
            {
                Place = Place.Place,//,
                //Time
                TrainerName = TrainerData.GetData().Name,
                TrainerID = TrainerData.GetData().ID
            },

            EValues = new EffortValues(),
            DValues = GetGenes()
        };

        Pokemon.Moves = GetMoveList(Pokemon);
        Pokemon.Experience = Experience.GetExperience(PokemonData.Breeding.LvlRate, Pokemon.Level);
        Pokemon.Stats = GetStats(Pokemon);
        ResetLiveStats(Pokemon);

        return Pokemon;
    }

    static Monster GetByRarity(PlaceData PlaceData)
    {
        float RandomNumber = Random.Range(0f, 100f);
        //Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "RandomNumber = " + RandomNumber);

        List<int> Chances = new List<int>();

        foreach (Place_MonsterTree Tree in PlaceData.MonsterTree)
        {
            Chances.Add(Tree.Rarity);
        }

        Chances.Sort();

        int choosenRarity = 0;

        for (int i = 0; i < Chances.Count; i++)
        {
            if (Chances[i] >= RandomNumber)
            {
                choosenRarity = Chances[i];

                break;
            }

            choosenRarity = Chances[Chances.Count - 1];
        }

        //Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "choosenRarity = " + choosenRarity);

        Monster newMonster = Monster.none;

        for (int i = 0; i < PlaceData.MonsterTree.Length; i++)
        {
            //Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "MonsterRarity = " + PlaceData.MonsterTree[i].Rarity);

            if (PlaceData.MonsterTree[i].Rarity == choosenRarity)
            {
                //Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "Rarity = " + PlaceData.MonsterTree[i].Rarity);

                newMonster = PlaceData.MonsterTree[i].Monster;
            } 
        }

        if (newMonster != Monster.none)
            return newMonster;

        else
        {
            Logger.Error(MethodBase.GetCurrentMethod().DeclaringType, "Could not find a fitting Monster - Please check the Method!");

            return PlaceData.MonsterTree[0].Monster;
        }
    }

    static P_Stats GetStats(BasePokemon Pokemon)
    {
        List<int> List = StatCalculator.CalculateStats(Pokemon);

        P_Stats newStats = new P_Stats()
        {
            HP = List[0],
            Attack = List[1],
            Defense = List[2],
            SpecialAttack = List[3],
            SpecialDefense = List[4],
            Speed = List[5],
        };

        return newStats;
    }

    static int GetLevel(PlaceData Place, PokemonData Pokemon)
    {
        for (int i = 0; i < Place.MonsterTree.Length; i++)
        {
            if (Place.MonsterTree[i].Monster == Pokemon.GeneralInformation.Monster)
                return Random.Range(Place.MonsterTree[i].Levels[0], Place.MonsterTree[i].Levels[1]);
        }

        Logger.Error(MethodBase.GetCurrentMethod().DeclaringType, "For some Reason the choosen Monster is not present in the PlaceData. Method returns '1'.");
        return 1;
    }

    static DeterminantValues GetGenes()
    {
        DeterminantValues Genes = new DeterminantValues()
        {
            HP = Random.Range(0, 32),
            Attack = Random.Range(0, 32),
            Defense = Random.Range(0, 32),
            SpecialAttack = Random.Range(0, 32),
            SpecialDefense = Random.Range(0, 32),
            Speed = Random.Range(0, 32)
        };

        return Genes;
    }

    static P_Ability GetRandomAbility(PokemonData Pokemon)
    {
        if (Pokemon.GeneralInformation.Ability_1 != P_Ability.none)
        {
            if (Random.Range(0, 2) == 0)
                return Pokemon.GeneralInformation.Ability_0;
            else
                return Pokemon.GeneralInformation.Ability_1;
        }

        else if (Pokemon.GeneralInformation.Ability_0 != P_Ability.none)
            return Pokemon.GeneralInformation.Ability_0;

        Logger.Error(MethodBase.GetCurrentMethod().DeclaringType, Pokemon.GeneralInformation.Name + " does not have a valid Ability!");
        return P_Ability.none;
    }

    public static void ResetLiveStats(BasePokemon Pokemon, bool HP)
    {
        if (HP)
            Pokemon.LiveStats.HP = Pokemon.Stats.HP;

        Pokemon.LiveStats.Attack = Pokemon.Stats.Attack;
        Pokemon.LiveStats.Defense = Pokemon.Stats.Defense;
        Pokemon.LiveStats.SpecialAttack = Pokemon.Stats.SpecialAttack;
        Pokemon.LiveStats.SpecialDefense = Pokemon.Stats.SpecialDefense;
        Pokemon.LiveStats.Speed = Pokemon.Stats.Speed;
    }

    public static void ResetLiveStats(BasePokemon Pokemon)
    {
        ResetLiveStats(Pokemon, true);
    }

    static bool CheckForShiny()
    {
        int Chance = 4096;

        return Random.Range(0, Chance) == 0;
    }

    static Gender GetRandomGender(PokemonData Pokemon)
    {
        if (Pokemon.Breeding.hasGender)
        {
            if (Pokemon.Breeding.MaleRatio >= Random.Range(0f, 1f))
                return Gender.Male;
            
            else
                return Gender.Female;
        }

        else
            return Gender.None;
    }

    /// <summary>
    /// Picks the last 4 moves that the given Pokemon can learn by level-up.
    /// Entries 1, 2 & 3 can be null!
    /// </summary>
    /// <param name="Pokemon">Pokemon</param>
    /// <returns>4 BaseMoves in an Array</returns>
    static BaseMove[] GetMoveList(BasePokemon Pokemon)
    {
        PokemonData Data = PokemonData.GetData(Pokemon.Monster);

        List<Move> newMoveList = new List<Move>();

        //Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "Data.MoveList.Length = " + Data.MoveList.Length);

        for (int i = 1; i < Data.MoveList.Length; i++)
        {
            P_Moves newMove = Data.MoveList[Data.MoveList.Length - i];

            if (newMove.MoveTree == P_MoveTree.LevelUp && newMove.LvlUP <= Pokemon.Level)
                newMoveList.Add(newMove.Move);

            if (newMoveList.Count == 4)
                break;
        }

        BaseMove[] BaseMoveList = new BaseMove[4];

        for (int i = 0; i < newMoveList.Count; i++)
        {
            BaseMoveList[i] = new BaseMove()
            {
                Move = newMoveList[i],
                CurrentPP = MoveData.GetData(newMoveList[i]).PP,
                MaxPP = MoveData.GetData(newMoveList[i]).PP,
                isDisabled = false
            };
        }

        if (BaseMoveList[0] != null)
            return BaseMoveList;

        else
        {
            Logger.Exception(MethodBase.GetCurrentMethod().DeclaringType, "'" + Pokemon.Monster + "' does not have a valid Move in its 'Moves' variable!");

            return null;
        }

    }
}