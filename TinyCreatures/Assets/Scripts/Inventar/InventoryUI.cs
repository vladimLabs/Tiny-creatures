using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    //�������� ���������
    [SerializeField] private GameObject inventorySlotPrefab; // ������ ����� ���������
    [SerializeField] private Transform inventoryPanel; // ������������ ������� ��� ������ � UI

    public static InventoryUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void DisplayInventoryFood()
    {
        foreach(Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        Inventory inventory = InventorySave.LoadInventory();
        foreach (var item in inventory.items)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, inventoryPanel);
            slot.GetComponent<InventorySlot>().SetInfo(item.quantity, FoodDatabase.Instance.GetFoodInfo(item.itemName));
        }
    }

}
