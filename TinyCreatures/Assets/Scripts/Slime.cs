using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Slime
{
    public string name;
    public int daysAlive;
    public float joyLevel;
    public float satietyLevel;
    public int evolutionProgress;
    public string subtype;

    public Slime(string nameSlime)
    {
        // Базовая инициализация для новой игры
        name = nameSlime;
        daysAlive = 0;
        joyLevel = 50; // Например, начальный уровень
        satietyLevel = 50; // Начальный уровень
        evolutionProgress = 0;
        subtype = "None";
    }

    public void Feed(float joy, float satiety)
    {
        joyLevel+=joy;
        satietyLevel+=satiety;

        joyLevel = Mathf.Max(0, joyLevel);
        satietyLevel = Mathf.Max(0, satietyLevel);
    }
}