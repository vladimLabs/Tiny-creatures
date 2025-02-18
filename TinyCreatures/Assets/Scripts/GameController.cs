using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public int coins; // �������� ����� ��� �������

    public Slime currentSlime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �����������, ���� �� ������, ����� GameController ���������� ����� �������.
        }
        else
        {
            Destroy(gameObject);
        }

        currentSlime = Save.LoadGame(); // ��������� ������ �� ����������
    }

    void Start()
    {
        coins = 100; // ��������� ���������� �����, ������
    }

    // ������ ��� ���������� ��������
    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            return true;
        }
        return false;
    }

    public int GetCoins()
    {
        return coins;
    }

    public void Feeding(Food food, int count)
    {
        //�������� �������� ���������
        Inventory inventory = InventorySave.LoadInventory();
        inventory.AddItem(food.name, count);
        InventorySave.SaveInventory(inventory); // ��������� ���������
        InventoryUI.Instance.DisplayInventoryFood();

        ChangeParametrsOfLife(food.happinessBonus, food.satietyBonus);

        AnimateSlime.Instance.EatHappyEmogy();
    }

    public void Loving()
    {
        ChangeParametrsOfLife(5, 0);
        AnimateSlime.Instance.EatHappyEmogy();
    }

    public void Playing()
    {
        ChangeParametrsOfLife(15, 0);
        AnimateSlime.Instance.EatHappyEmogy();
    }

    public void ChangeParametrsOfLife(float happinessBonus, float satietyBonus)
    {
        currentSlime.Feed(happinessBonus, satietyBonus);
        Save.SaveGame(currentSlime);

        HUD.Instance.UpdateHUD(currentSlime);
        AnimateSlime.Instance.SetHappyParametr(currentSlime.joyLevel);
    }

    public void NewDayLife()
    {
        currentSlime.daysAlive++;
        Save.SaveGame(currentSlime);
    }
}
