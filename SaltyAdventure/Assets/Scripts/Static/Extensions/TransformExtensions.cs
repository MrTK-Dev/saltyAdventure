using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    /// <summary>
    /// Returns a List of Children with the given Tag.
    /// </summary>
    public static List<GameObject> FindObjectsWithTag(this Transform parent, string tag)
    {
        List<GameObject> taggedGameObjects = new List<GameObject>();

        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == tag)
            {
                taggedGameObjects.Add(child.gameObject);
            }
            if (child.childCount > 0)
            {
                taggedGameObjects.AddRange(FindObjectsWithTag(child, tag));
            }
        }
        return taggedGameObjects;
    }

    /// <summary>
    /// Returns a List of all Children.
    /// </summary>
    public static List<GameObject> GetChildren(this Transform parent)
    {
        List<GameObject> ChildrenList = new List<GameObject>();

        for (int i = 0; i < parent.childCount; i++)
        {
            ChildrenList.Add(parent.GetChild(i).gameObject);
        }

        return ChildrenList;
    }

    /// <summary>
    /// Returns the Index of given Child.
    /// If the given Child is not a valid Child the function returns 0.
    /// ToDo give Error11
    /// </summary>
    public static int GetIndexOfChild(this Transform parent, GameObject child)
    {
        int Index = new int();

        if (child.transform.IsChildOf(parent))
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChildren()[i] == child)
                {
                    Index = i;
                }
            }

            return Index;
        }
        else
        {
            throw new System.Exception(child.name + " is not an child of " + parent.name);
        }
    }
}
