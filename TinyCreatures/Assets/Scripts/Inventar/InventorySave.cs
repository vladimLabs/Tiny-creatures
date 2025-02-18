using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class InventorySave
{
    private static string savePath = Application.persistentDataPath + "/inventoryitem.json";

    public static void StartNewGame()
    {
        Inventory inventory = new Inventory();
        inventory.AddItem("Apple", 20); // Добавляем 20 яблок в инвентарь при старте новой игры
        SaveInventory(inventory); // Сохраняем инвентарь
    }

    public static void SaveInventory(Inventory inventory)
    {
        string json = JsonUtility.ToJson(inventory, true);
        File.WriteAllText(savePath, json);
    }

    public static Inventory LoadInventory()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<Inventory>(json);
        }
        else
        {
            Inventory inventory = new Inventory();
            inventory.AddItem("Apple", 20); // Добавляем 20 яблок в инвентарь при старте новой игры
            return inventory;
        }
    }

    

}