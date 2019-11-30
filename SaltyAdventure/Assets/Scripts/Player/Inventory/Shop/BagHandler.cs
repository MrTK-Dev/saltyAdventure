using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagHandler : MonoBehaviour
{
    public Bag Bag;

    public int ID;

    public Sprite Icon;
    public Sprite BG;

    public string Name = "default Name";
    public string Description = "default Description";
    public string Category = "default Category";

    public int SlotCapacity = 10;

    public List<Item> ItemList;
    public Item CachedItem;

    private void Start()
    {
        ID = Bag.ID;
        Icon = Bag.Icon;
        BG = Bag.BG;

        Name = Bag.Name;
        Description = Bag.Description;
        Category = Bag.Category;

        SlotCapacity = 10;
        CachedItem = Bag.CachedItem;
    }
}
