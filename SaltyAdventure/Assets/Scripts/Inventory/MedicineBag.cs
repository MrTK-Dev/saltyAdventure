using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineBag : MonoBehaviour
{
    public static MedicineBag instance;

    public int SlotCapacity = 10;

    public List<Item> ItemList = new List<Item>();

}
