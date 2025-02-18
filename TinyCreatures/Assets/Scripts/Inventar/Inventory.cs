using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddItem(string itemName, int quantity)
    {
        // �������� �� ������� �������� � ��������� � ���������� ��� ����������
        var existingItem = items.Find(item => item.itemName == itemName);
        if (existingItem != null)
        {
            existingItem.quantity += quantity;
        }
        else
        {
            items.Add(new InventoryItem(itemName, quantity));
        }
    }

    
}