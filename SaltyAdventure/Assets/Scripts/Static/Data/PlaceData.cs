using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceData
{
    public Place Place = Place.none;
    public string Name = "Placeholder Name";
    public string Description = "Placeholder Description";

    public Place_MonsterTree[] MonsterTree;

    public static int Count { get { return Database.Length; } }
    public static PlaceData[] Database;

    static PlaceData()
    {
        Database = new PlaceData[]
        {
            new PlaceData()
            {

            },

            new PlaceData()
            {
                Place = Place.Route1,
                Name = "Route 1",
                Description = "cool Route",
                MonsterTree = new Place_MonsterTree[]
                {
                    new Place_MonsterTree()
                    {
                        Monster = Monster.bulbasaur,
                        Levels = new int[] {5, 10},
                        Rarity = 0.5f
                    }
                }
            }
        };
    }

    public static PlaceData GetData(int Index)
    {
        return Database[Index];
    }

    public static PlaceData GetData(Place Place)
    {
        for (int i = 0; i < Count; i++)
        {
            if (Database[i].Place == Place)
            {
                return Database[i];
            }
        }

        return Database[0];
    }

    public static PlaceData[] GetDatabase()
    {
        return Database;
    }
}

public enum Place
{
    none,
    Route1
}

public class Place_MonsterTree
{
    public Monster Monster = Monster.none;
    public int[] Levels = new int[2];
    public float Rarity;
    //public Kindofplace
}