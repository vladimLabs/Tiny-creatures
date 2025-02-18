using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReward
{
    void GetReward(int day);
}

public class RewardCoin : IReward
{
    private int amount;

    public RewardCoin(int amount)
    {
        this.amount = amount;
    }

    public void GetReward(int day)
    {
        Debug.Log($"Выдано {amount} монет за день {day}.");
        // Здесь логика добавления монет игроку
    }
}

public class RewardFood : IReward
{
    private string foodName;
    private int quantity;

    public RewardFood(string foodName, int quantity)
    {
        this.foodName = foodName;
        this.quantity = quantity;
    }

    public void GetReward(int day)
    {
        Debug.Log($"Выдано {quantity} единиц еды '{foodName}' за день {day}.");
        // Здесь логика добавления еды игроку
    }
}


public class RewardManager : MonoBehaviour
{
    private static List<IReward> rewards = new List<IReward>();

    void Awake()
    {
        InitializedListReward();
    }

    private void InitializedListReward()
    {
        rewards.Add(new RewardCoin(100)); // Награда за 1-й день
        rewards.Add(new RewardFood("Яблоко", 5)); // Награда за 2-й день
                                                  // Добавляйте дополнительные награды по аналогии

    }

    public static void GetDailyReward(int numberDay)
    {
        Debug.Log(numberDay + " " + rewards.Count);
        rewards[numberDay - 1].GetReward(numberDay);
    }
}
