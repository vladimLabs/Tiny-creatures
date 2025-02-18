using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public string itemName;
    public int quantity;

    public InventoryItem(string name, int quantity)
    {
        this.itemName = name;
        this.quantity = quantity;
    }
}
