using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [System.Serializable]
    public class FoodItem
    {
        public string nameFood;
        public int cost;

        public FoodItem(string food, int cost)
        {
            this.nameFood = food;
            this.cost = cost;
        }
    }

    [SerializeField]
    private List<FoodItem> foodItemsAvailable = new List<FoodItem>();

    void Start()
    {
        InitializeShop();
    }

    void InitializeShop()
    {
        // Создание и добавление товаров в магазин
        AddFoodItem("Apple", 15);
        AddFoodItem("Carrot", 25);
        AddFoodItem("Meat", 50);
    }

    public void AddFoodItem(string nameFood, int cost)
    {
        foodItemsAvailable.Add(new FoodItem(nameFood, cost));
    }

    // Метод для покупки еды
    /*public bool BuyFood(string foodName)
    {
        int cost = GetFoodCost(foodName);
        if (cost != -1 && GameController.Instance.SpendCoins(cost))
        {
            // Покупка успешно совершена
            Debug.Log($"Bought {foodName} for {cost} coins.");
            return true;
        }
        else
        {
            Debug.Log("Not enough coins or food not found.");
            return false;
        }
     }*/

    // Дополнительные методы...
}
