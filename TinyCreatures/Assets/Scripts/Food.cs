using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Food
{
    public string name;
    public float happinessBonus;
    public float satietyBonus;

    public Food(string name, float happinessBonus, float satietyBonus)
    {
        this.name = name;
        this.happinessBonus = happinessBonus;
        this.satietyBonus = satietyBonus;
    }

   

}
