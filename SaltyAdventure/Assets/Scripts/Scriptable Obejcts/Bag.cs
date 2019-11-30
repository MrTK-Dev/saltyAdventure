using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bag", menuName = "Inventory/Bag")]
public class Bag : ScriptableObject
{
    public int ID = 0;

    public Sprite Icon;
    public Sprite BG;

    public string Name = "default Name";
    public string Description = "default Description";
    public string Category = "default Category";

    public int SlotCapacity = 10;

    public Item CachedItem;
}
