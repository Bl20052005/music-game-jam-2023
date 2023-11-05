using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public List<string> inventory = new List<string>();

    public void addItem(string item)
    {
        inventory.Add(item);
    }

    public bool contains(string item)
    {
        if (inventory.Contains(item))
        {
            return true;
        }

        return false;
    }
}