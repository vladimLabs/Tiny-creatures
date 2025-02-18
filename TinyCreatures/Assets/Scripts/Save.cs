using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public static class Save
{
    private static string savePath = Application.persistentDataPath + "/slime.json";

    public static void SaveGame(Slime slime)
    {
        string json = JsonUtility.ToJson(slime);
        File.WriteAllText(savePath, json);
    }

    public static Slime LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<Slime>(json);
        }
        return new Slime("Slime"); // Возвращает новый экземпляр Slime, если сохранение не найдено
    }

    public static void NewGame(string newName)
    {
        Slime newSlime = new Slime(newName); // Создает новый базовый экземпляр Slime
        SaveGame(newSlime); // Сохраняет новую игру
    }
}
