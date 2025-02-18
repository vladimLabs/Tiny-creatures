using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDatabase : MonoBehaviour
{
    public static FoodDatabase Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField]
    private List<Food> foodItemsAvailable = new List<Food>();

    void Start()
    {
        InitializeShop();
    }

    void InitializeShop()
    {
        AddFoodItem("Apple", 15, 20);
        AddFoodItem("Carrot", 25, 25);
        AddFoodItem("Meat", 50, 70);
    }

    public void AddFoodItem(string nameFood, float happinessBonus, float satietyBonus)
    {
        foodItemsAvailable.Add(new Food(nameFood, happinessBonus, satietyBonus));
    }

    public Food GetFoodInfo(string name)
    {
        foreach (Food item in foodItemsAvailable)
        {
            if (item.name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
            {
                return item;
            }
        }
        return null; // ¬озвращает null, если еда с таким именем не найдена
    }
}
