using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PokeballBag : MonoBehaviour
{
    public static PokeballBag instance;

    public int SlotCapacity = 10;

    public List<Item> ItemList = new List<Item>();
}
