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
        Debug.Log($"������ {amount} ����� �� ���� {day}.");
        // ����� ������ ���������� ����� ������
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
        Debug.Log($"������ {quantity} ������ ��� '{foodName}' �� ���� {day}.");
        // ����� ������ ���������� ��� ������
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
        rewards.Add(new RewardCoin(100)); // ������� �� 1-� ����
        rewards.Add(new RewardFood("������", 5)); // ������� �� 2-� ����
                                                  // ���������� �������������� ������� �� ��������

    }

    public static void GetDailyReward(int numberDay)
    {
        Debug.Log(numberDay + " " + rewards.Count);
        rewards[numberDay - 1].GetReward(numberDay);
    }
}
